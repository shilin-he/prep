using System;
using System.Collections.Generic;
using System.Linq;
using prep.utility.matching;

namespace prep.utility.comparisons
{
  public enum Colour
  {
    red,
    white
  }
  public interface IIntoxicate
  {
    double wholesale_cost { get; }
    Colour colour { get; set; }
  }

  public class RedWine : IIntoxicate
  {
    public double wholesale_cost { get; private set; }
    public Colour colour { get; set; }
  }

  public class WhiteWhine : IIntoxicate
  {
    public double wholesale_cost { get; private set; }
    public Colour colour { get; set; }
  }

  public interface ICalculateWineMarkup
  {
    double calculate_markup(IIntoxicate wine);
  }



  public class Bootstrap 
  {
    public double calculate_markup_for(IEnumerable<WineMarkupCalculator> markup, IIntoxicate wine)
    {
      ICalculateWineMarkup default_markup = new MarkupCalculator(x => x.wholesale_cost*.40);

      var strategy = markup.FirstOrDefault(x => x.can_calculate_markup_for(wine))
                    ?? default_markup;

      return strategy.calculate_markup(wine);
    }
    public static void run()
    {
      var all_markup_strategies = new List<WineMarkupCalculator>();

      var red_wine = Match<IIntoxicate>.with_attribute(x => x.colour).equal_to(Colour.red);
      var white_wine = Match<IIntoxicate>.with_attribute(x => x.colour).equal_to(Colour.white);

      var markup_at_10_percent = new MarkupCalculator(x => x.wholesale_cost*.10);
      var markup_at_20_percent = new MarkupCalculator(x => x.wholesale_cost*.20);


      all_markup_strategies.Add(new WineMarkupCalculator(red_wine, markup_at_10_percent));
      all_markup_strategies.Add(new WineMarkupCalculator(white_wine, markup_at_20_percent));

      var wine = new RedWine();


    }
  }

  public class ComplexCalculator : ICalculateWineMarkup
  {
    public double calculate_markup(IIntoxicate wine)
    {
      throw new NotImplementedException();
    }
  }
  public class MarkupCalculator : ICalculateWineMarkup
  {
    Func<IIntoxicate, double> markup_strategy;

    public MarkupCalculator(Func<IIntoxicate, double> markup_strategy)
    {
      this.markup_strategy = markup_strategy;
    }

    public double calculate_markup(IIntoxicate wine)
    {
      return markup_strategy(wine);
    }
  }
  public class WineMarkupCalculator : ICalculateWineMarkup
  {
    IMatchA<IIntoxicate> wine_match;
    ICalculateWineMarkup calculator;

    public WineMarkupCalculator(IMatchA<IIntoxicate> wine_match, ICalculateWineMarkup calculator)
    {
      this.wine_match = wine_match;
      this.calculator = calculator;
    }

    public double calculate_markup(IIntoxicate wine)
    {
      return calculator.calculate_markup(wine);
    }

    public bool can_calculate_markup_for(IIntoxicate wine)
    {
      return wine_match.matches(wine);
    }
  }

}