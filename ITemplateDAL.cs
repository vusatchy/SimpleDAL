using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface  ITemplateDAL<T>
    {
        //get
         T getById(int id);
        //create
         void add(T obj);
        //update
         void update(T obj);
        //delete
         void delete(T obj);
        //get all
         List<T> getAll();
     
    }
}
