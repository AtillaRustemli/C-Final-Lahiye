using System.Text;
using BookShop.AuthorStructure;
using BookShop.BookData;
using BookShop.Enums;
using BookShop.Helper;
using BookShop.NewFoldeManagersr;

namespace Test
{
    internal class BookShop
    {
        /*        - Author CRUD
                

AuthorStructure :
                                    Id             number (++)
                                    Name      text
                                    Surname text
               =========================
                - CREATE    (Add)
                - READ        (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE    (Remove)

             - Book CRUD
                

BookStructure :
                                    Id            number (++)
                                    Name          text
                                    AuthorId      number
                                    Genre         enum
                                    PageCount     number
                                    Price         number(decimal)
               =========================
                - CREATE   (Add)
                - READ     (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE   (Remove)*/

        
        static void Main(string[] args)
        {

            const string file = @"C:\Users\MSI\Desktop\BookShop\Bookdata";
            string txt = "Salam,Dunya!";
            string text = "Salam,Insanlar!";

            File.WriteAllText(file, txt);
            File.WriteAllText(file, text);


             BookManager bookManager = new BookManager();

            bookManager.Add(new Book { Name = "Dede qorqud" ,PageCount=216,Price=10,AuthorId=1,BookGenre=BookGenre.Horror});
            bookManager.Add(new Book { Name = "Bir gencin manifesti" });
            AuthorManager authorManager = new AuthorManager();



            

            Menu choose;
            
            Author author;
            Book book;
            int id;
            l1:
            Console.WriteLine("Etmek istediyiniz emeliyyati menudan secin: ");
            choose = Helper.ReadEnum<Menu>("Secim: ");
            switch (choose)
            {
                case Menu.BookAdd:

                    book = new Book();
                    book.Name = Helper.ReadString("Kitabin adi:");
                    book.Name = Helper.ReadString("Kitabin adi:");
                    book.Name = Helper.ReadString("Kitabin adi:");
                    book.Name = Helper.ReadString("Kitabin adi:");
                    book.Name = Helper.ReadString("Kitabin adi:");
                    bookManager.Add(book);

                    Console.Clear();
                    Console.WriteLine("Etmek istediyiniz emeliyyati menudan secin: ");
                    
                    goto l1;
                case Menu.BookEdit:
                    Console.WriteLine("Deyisiklik etmek istediyiniz kitabi secin: ");
                    foreach (var item in bookManager)
                    {
                        Console.WriteLine(item);
                    }
                    
                    id = Helper.ReadInt("Kitab id");
                    book = bookManager.GetById(id);
                    if (id == 0)
                        goto l1;
                    if (book == null)
                    {

                        Console.Clear();
                        goto case Menu.BookEdit;
                    }
                    book.Name = Helper.ReadString("Kitabin adi:");
                    Console.Clear();
                    goto case Menu.BookGetAll;

                    
                    
                case Menu.BookRemove:
                    Console.WriteLine("Redakde etmek istediyiniz kitabi secin: ");
                    foreach (var item in bookManager)
                    {
                        Console.WriteLine(item);
                    }
                    id = Helper.ReadInt("Kitab id:");
                    book = bookManager.GetById(id);
                    if (book == null)
                    {
                        Console.Clear();
                        goto case Menu.BookGetAll;
                    }
                    bookManager.Remove(book);
                    Console.Clear();
                    goto case Menu.BookGetAll;
                    

                case Menu.BookGetAll:
                    Console.Clear();
                    foreach (var item in bookManager)
                    {
                        
                        Console.WriteLine(item);
                    }
                    
                   
                    
                    goto l1;


                case Menu.BookFindByName:

                    string name=Helper.ReadString("Axtardiginiz kitabin en az ilk 3 herfini qeyd edin");
                    var data = bookManager.FindByName(name);
                    if (data.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                    foreach (var item in data)
                    {
                        Console.WriteLine(item);
                    }

                    goto l1;


                case Menu.BookGetById:
                   
                    id = Helper.ReadInt("Kitab id");

                    if (id == 0)
                    {
                        Console.Clear();
                        goto l1;
                    }
                    book = bookManager.GetById(id);

                    if (book == null)
                    {

                        Console.Clear();
                        goto case Menu.BookGetById;
                    }
                    Console.WriteLine(book);
                    goto l1;


                //-------------------------------------------------------------
                //-------------------------------------------------------------

                case Menu.AuthorAdd:

                    author = new Author();
                    author.Name = Helper.ReadString("Muellifin adi:");
                    authorManager.Add(author);

                    Console.Clear();
                    Console.WriteLine("Etmek istediyiniz emeliyyati menudan secin: ");

                    goto l1;
                case Menu.AuthorEdit:
                    Console.WriteLine("Deyisikmek istediyiniz muellifi: ");
                    foreach (var item in authorManager)
                    {
                        Console.WriteLine(item);
                    }

                    id = Helper.ReadInt("Muellif id");
                    author = authorManager.GetById(id);
                    if (id == 0)
                        goto l1;
                    if (author == null)
                    {

                        Console.Clear();
                        goto case Menu.AuthorEdit;
                    }
                    author.Name = Helper.ReadString("Muellifin adi:");
                    Console.Clear();
                    goto case Menu.AuthorGetAll;



                case Menu.AuthorRemove:
                    Console.WriteLine("Silmek istediyiniz muellifi secin: ");
                    foreach (var item in authorManager)
                    {
                        Console.WriteLine(item);
                    }
                    id = Helper.ReadInt("Muellifi id:");
                    author = authorManager.GetById(id);
                    if (author == null)
                    {
                        Console.Clear();
                        goto case Menu.AuthorGetAll;
                    }
                    authorManager.Remove(author);
                    Console.Clear();
                    goto case Menu.AuthorGetAll;


                case Menu.AuthorGetAll:
                    Console.Clear();
                    foreach (var item in authorManager)
                    {

                        Console.WriteLine(item);
                    }



                    goto l1;


                case Menu.AuthorFindByName:

                    string AutName = Helper.ReadString("Axtardiginiz Muellifin Adinin en az ilk 3 herfini qeyd edin");
                    var AutData = authorManager.FindByName(AutName);
                    if (AutData.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                    foreach (var item in AutData)
                    {
                        Console.WriteLine(item);
                    }

                    goto l1;


                case Menu.AuthorGetById:

                    id = Helper.ReadInt("Muellif id");

                    if (id == 0)
                    {
                        Console.Clear();
                        goto l1;
                    }
                    author = authorManager.GetById(id);

                    if (author == null)
                    {

                        Console.Clear();
                        goto case Menu.AuthorGetById;
                    }
                    Console.WriteLine(author);
                    goto l1;


            }




            //foreach (var item in authorManager)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }



}
  
            //Book book = new Book();
            //book.Name = "Qisasin Olcusu";
            //book.PageCount = 317;
            //book.Price = 4;
            //book.AuthorId = author.Id;
            //bookManager.Add(book);

            //Book book2 = new Book();
            //book2.Name = "Bir Gecin Manifesti";
            //book2.PageCount = 263;
            //book2.Price = 5.5M;
            //book2.AuthorId = author2.Id;
            //bookManager.Add(book2);

            //Book book3 = new Book();
            //book3.Name = "Kicik qehreman";
            //book3.PageCount = 226;
            //book3.Price = 7.5M;
            //book3.AuthorId = author3.Id;
            //bookManager.Add(book3);