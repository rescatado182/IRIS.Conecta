namespace IRIS.UI.Models.List
{
    public class GetUserByUserIdVM
    {

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
 

        public string FullName {

            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
