namespace ConsoleForum
{
    public static class Messages
    {
        public const string InvalidCommand = "Invalid command!";
        public const string UserAlreadyRegistered = "User with the same mail or username already exists";
        public const string InvalidLoginDetails = "Wrong username/password or username not registered";
        public const string AlreadyLoggedIn = "Already logged in. In order to switch to another user - logout first";
        public const string RegAdminNotAllowed = "Cannot register administrator";
        public const string NoPermission = "You do not have enough permission to perform the desired operation";
        public const string NotLogged = "Operation not permitted. You have to login first";
        public const string NoQuestionOpened = "Operation not permitted. You have to open a question first";
        public const string NoQuestions = "No questions";
        public const string NoQuestion = "No such question";
        public const string NoAnswer = "No such answer";
        public const string NoUser = "No such user";
        
        public const string RegisterSuccess = "User {0} with Id: {1} successfully registered";
        public const string LoginSuccess = "User {0} successfully logged in";
        public const string LogoutSuccess = "Logout success";
        public const string PostQuestionSuccess = "Question with Id: {0} successfully posted";
        public const string PostAnswerSuccess = "Answer with Id: {0} successfully posted";
        public const string OpenQuestionSuccess = "Question {0} opened";
        public const string RoleChangeSuccess = "Role successfully changed";
        public const string BestAnswerSuccess = "Answer with Id: {0} successfully made best answer";

        public const string GuestWelcomeMessage = "Hey stranger, care to login/register?";
        public const string UserWelcomeMessage = "Welcome, {0}!";
        public const string GeneralHeaderMessage = "Hot questions: {0}, Active users: {1}";
    }
}
