using System.Collections;
using BookShop.BookData;
using BookShop.Infrastructure;

namespace BookShop.NewFoldeManagersr
{
    internal class BookManager : IManager<Book>, IEnumerable<Book>
    {

        Book[] data = new Book[0];
        public void Add(Book item)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = item;

        }

        public void Edit(Book item)
        {
            int index = Array.IndexOf(data, item);
            if (index == -1)
            {
                return;
            }
            var found = data[index];
            found.Name = item.Name;
            found.AuthorId = item.AuthorId;
            found.PageCount = item.PageCount;
            found.Price = item.Price;
            found.BookGenre = item.BookGenre;
        }
        public void Remove(Book item)
        {
            int index = Array.IndexOf(data, item);

            if (index == -1)
            {
                return;
            }

            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            Array.Resize(ref data, data.Length - 1);
        }

        public Book GetById(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public Book[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.ToLower().StartsWith(name.ToLower()));
        }
        public Book this[int index]
        {

            get
            {
                return data[index];
            }

        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book item in data)
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
