using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.AuthorStructure;
using BookShop.BookData;
using BookShop.Infrastructure;

namespace BookShop.NewFoldeManagersr
{
    public class AuthorManager : IManager<Author>,IEnumerable<Author>

    {
        Author[] data = new Author[0];
        public void Add(Author item)
        {
            int len=data.Length;
            Array.Resize(ref data, len+1);
            data[len] = item;


        }

        public void Edit(Author item)
        {
            int index= Array.IndexOf(data, item);
            if (index == -1)
            {
                return;
            }
            var found = data[index];
            found.Name= item.Name;
            found.Surname= item.Surname;
            
        }


        public void Remove(Author item)
        {
            int index=Array.IndexOf(data, item);

            if (index == -1)
            {
                return;
            }

            for (int i = index; i < data.Length-1; i++)
            {
                data[i] = data[i + 1];
            }
            Array.Resize(ref data, data.Length - 1);
        }

        public Author GetById(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }
        public Author[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.StartsWith(name));
        }

        public Author this[int index] {
            
            get 
            { 
            return data[index];
            }
        
        }

        public IEnumerator<Author> GetEnumerator()
        {
            foreach (Author item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }

        
    }
}
