#load "services.csx"

// Mediator
var chat = new ChatService();

// Colleagues
var user = new User(chat);
var admin = new Admin(chat);

// Add
chat.User = user;
chat.Admin = admin;

// Send
user.Send("I have a problem");
admin.Send("Ok, tell me what's your problem");
