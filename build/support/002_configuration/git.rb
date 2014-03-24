configs ={
  :git => {
    :provider => 'github',
    :user => 'aglcmarch2014',
    :remotes => %w/cmanners jreyes20 aglc-dennis mshogren mruvinskiy samankodithuwakku mhaagsma shilin-he/,
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
