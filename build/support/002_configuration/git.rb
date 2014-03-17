configs ={
  :git => {
    :provider => 'github',
    :user => 'aglcmarch2014',
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
