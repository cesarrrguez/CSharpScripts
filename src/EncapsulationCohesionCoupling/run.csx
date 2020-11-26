#load "data.csx"

var sqlContext = new SqlContext();
//var xmlContext = new XmlContext();

var userRepository = new UserRepository(sqlContext);
var user = new User();
userRepository.Add(user);
userRepository.Delete(user.GetId());
