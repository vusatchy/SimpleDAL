using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Services;
using DAL;

namespace DALTask
{
    class Program
    {
        static void Main(string[] args)
        {
           /* UserService servie = new UserService();
            List<User> users = servie.getAll();
            foreach (User us in users)
            {
                Console.WriteLine(us);
            }
            User user = new User();
            user.id=6;
            user.login="lol";
            user.password = "176384919414";
            user.sex = Sex.MALE;
            user.registrationTime = DateTime.Now;
            servie.delete(user);*/
            /*ITemplateDAL<Feedback> fService = new FeedbackService();
            List<Feedback> feedbacks = fService.getAll();
            foreach (Feedback f in feedbacks)
            {
                Console.WriteLine(f);
                Console.WriteLine("+----------------------------------------------------------------+");
            }*/
            ITemplateDAL<Product> pService = new ProductService();
            List<Product> products = pService.getAll();
            foreach (Product p in products)
            {
                Console.WriteLine(p);
                Console.WriteLine("+++++++++++++++++++++++");
            }
            Console.WriteLine();
            Console.ReadKey();

         
        }
    }
}
