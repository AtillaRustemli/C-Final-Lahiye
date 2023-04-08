using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.AuthorStructure;
using System.Xml.Linq;
using BookShop.Enums;

namespace BookShop.BookData
{
    public class Book : IEquatable<Book>
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.Id = counter;

        }
       
        public bool Equals(Book? other)
        {

            return other?.Id == this.Id;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
       
        public BookGenre BookGenre { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Name} || Muellifin id-si: {AuthorId} || Janri: {BookGenre} || Sehife sayi: {PageCount} || Qiymeti: {Price}";
        }

    }
}
