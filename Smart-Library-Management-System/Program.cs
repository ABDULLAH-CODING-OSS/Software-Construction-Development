using System;
using System.Collections.Generic;
using static SmartLibrarySystem.Program;
namespace SmartLibrarySystem
{

    class Program
    {
      static void Main(string[] args) {
            Library library = new Library("Smart Community Library");

            library.addItem(new Book("B001", "The Great Gatsby", "F. Scott Fitzgerald"));
            library.addItem(new Book("B002", "To Kill a Mockingbird", "Harper Lee"));
            library.addItem(new Magzine("M001", "National Geographic", "Nat Geo Partners", 215));
            library.addItem(new DigitalMedia("D001", "C# Programming Guide", "PDF", 12.5));
            // Additional seeded items (Pakistani culture oriented)
            library.addItem(new Book("B003", "Aangan", "Qurratulain Hyder"));
            library.addItem(new Book("B004", "Naruto Vol.1", "Masashi Kishimoto"));
            library.addItem(new Magzine("M002", "Dawn", "Dawn Media Group", 102));
            library.addItem(new Magzine("M003", "Jang", "Jang Group", 98));
            // DVDs represented as DigitalMedia with format "DVD"
            library.addItem(new DigitalMedia("DVD001", "Waar", "DVD", 4700));
            library.addItem(new DigitalMedia("DVD002", "Khuda Kay Liye", "DVD", 4300));
            library.addItem(new DigitalMedia("DVD003", "Joyland", "DVD", 3800));

            // Seed some initial members
            library.registerMember(new Member("U001", "Alice"));
            library.registerMember(new PremiumMember("U002", "Bob", 49.99));

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n========= Smart Community Library =========");
                Console.WriteLine("1. Display Catalog");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Add Magazine");
                Console.WriteLine("4. Add Digital Material");
                Console.WriteLine("5. Register General Member");
                Console.WriteLine("6. Register Premium Member");
                Console.WriteLine("7. Borrow Item");
                Console.WriteLine("8. Return Item");
                Console.WriteLine("9. Display All Members");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.DisplayLibraryInfo();
                        break;

                    case "2":
                        Console.Write("Enter Book ID: ");
                        string bId = Console.ReadLine();
                        Console.Write("Enter Title: ");
                        string bTitle = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string bAuthor = Console.ReadLine();
                        library.addItem(new Book(bId, bTitle, bAuthor));
                        break;

                    case "3":
                        Console.Write("Enter Magazine ID: ");
                        string mId = Console.ReadLine();
                        Console.Write("Enter Title: ");
                        string mTitle = Console.ReadLine();
                        Console.Write("Enter Publisher: ");
                        string mPub = Console.ReadLine();
                        Console.Write("Enter Issue Number: ");
                        int mIssue = int.Parse(Console.ReadLine());
                        library.addItem(new Magzine(mId, mTitle, mPub, mIssue));
                        break;

                    case "4":
                        Console.Write("Enter Digital Material ID: ");
                        string dId = Console.ReadLine();
                        Console.Write("Enter Title: ");
                        string dTitle = Console.ReadLine();
                        // Only DVD file type is allowed for digital material in this app
                        string dFormat = "DVD";
                        Console.WriteLine("File Format: DVD (only)");
                        Console.Write("Enter File Size (MB): ");
                        double dSize = double.Parse(Console.ReadLine());
                        library.addItem(new DigitalMedia(dId, dTitle, dFormat, dSize));
                        break;

                    case "5":
                        Console.Write("Enter Member ID: ");
                        string gmId = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        string gmName = Console.ReadLine();
                        library.registerMember(new Member(gmId, gmName));
                        break;

                    case "6":
                        Console.Write("Enter Member ID: ");
                        string pmId = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        string pmName = Console.ReadLine();
                        Console.Write("Enter Membership Fee: ");
                        double pmFee = double.Parse(Console.ReadLine());
                        library.registerMember(new PremiumMember(pmId, pmName, pmFee));
                        break;

                    case "7":
                        Console.Write("Enter Member ID: ");
                        string borrowMId = Console.ReadLine();
                        Member borrower = library.findMember(borrowMId);
                        if (borrower == null) { Console.WriteLine("Member not found."); break; }
                        Console.Write("Enter Item ID to borrow: ");
                        string borrowItemId = Console.ReadLine();
                        borrower.BorrowItem(borrowItemId, library.GetCatalog());
                        break;

                    case "8":
                        Console.Write("Enter Member ID: ");
                        string returnMId = Console.ReadLine();
                        Member returner = library.findMember(returnMId);
                        if (returner == null) { Console.WriteLine("Member not found."); break; }
                        Console.Write("Enter Item ID to return: ");
                        string returnItemId = Console.ReadLine();
                        // call the overload that accepts an item ID and the library catalog
                        returner.ReturnItem(returnItemId, library.GetCatalog());
                        break;

                    case "9":
                        library.DisplayLibraryInfo();
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }

    public class Library
    {
      private string _libraryName;
        private List<LibraryItem> _catalog;
        private List<Member> _members;
        public Library(string libraryName)
        {
            _libraryName = libraryName;
            _catalog = new List<LibraryItem>();
            _members = new List<Member>();
        }
        public void addItem(LibraryItem item)
        {
            _catalog.Add(item);
            Console.WriteLine($"Added {item.Title} to the library catalog.");
        }
        public void registerMember(Member member)
        {
            _members.Add(member);
            Console.WriteLine($"Registered member: {member.Name}");
        }
        public List<LibraryItem> GetCatalog()=> _catalog;
        public List<Member> GetMembers()=> _members;
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {_libraryName}");
            Console.WriteLine("Catalog:");
            foreach (var item in _catalog)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("Members:");
            foreach (var member in _members)
            {
                member.displayMemberInfo();
            }
        }
        public Member findMember(string memberId)
        {
            Member foundMember = _members.Find(m => m.MemberID == memberId);
            if (foundMember != null)
            {
                Console.WriteLine($"Found Member: {foundMember.Name} (ID: {foundMember.MemberID})");
                return foundMember;
            }
            else
            {
                Console.WriteLine($"Member with ID {memberId} not found.");
                return null;
            }
        }
    }

    public abstract class LibraryItem
    {
        private string _itemID;
        private string _title;
        private bool _isAvailable;

        public string itemId => _itemID;
        public string Title => _title;
        public bool _IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;

            }
        }
        public LibraryItem(string itemid, string title)
        {
            _itemID = itemid;
            _title = title;
            _IsAvailable = true;
        }
        public abstract void DisplayInfo();

    }

    public class Member
    {
        private string _memberID;
        private string _name;
        protected List<LibraryItem> _borrowedItems;
        protected int _borrowLimit;

        public string Name { get { return _name; } }
        public string MemberID { get { return _memberID; } }

        public Member(string memberId, string name)
        {
            _memberID = memberId;
            _name = name;
            _borrowedItems = new List<LibraryItem>();
            _borrowLimit = 2; // Default borrow limit
        }

        public virtual void BorrowItem(LibraryItem item)
        {
            // Only premium members can borrow digital media
            if (item is DigitalMedia)
            {
                Console.WriteLine($"{_name} Only premium members can borrow digital media.");
                return;
            }

            if (_borrowedItems.Count < _borrowLimit && item._IsAvailable)
            {
                item._IsAvailable = false;
                _borrowedItems.Add(item);
                Console.WriteLine($"{_name} Successfully borrowed {item.Title}");
            }
            else
            {
                Console.WriteLine($"{_name} Cannot borrow {item.Title}. Either borrow limit reached or item is not available.");
            }
        }

        public void BorrowItem(string itemId, List<LibraryItem> catalog)
        {
            LibraryItem foundItem = catalog.Find(item => item.itemId == itemId);
            if (foundItem != null)
            {
                BorrowItem(foundItem);
            }
            else
            {
                Console.WriteLine($"Item with ID {itemId} not found in catalog.");
            }
        }

        public void ReturnItem(LibraryItem item)
        {
            if (_borrowedItems.Contains(item))
            {
                item._IsAvailable = true;
                _borrowedItems.Remove(item);
                Console.WriteLine($"{_name} returned {item.Title}");
            }
            else
            {
                Console.WriteLine($"{_name} cannot return {item.Title} as it was not borrowed.");
            }
        }
        public void ReturnItem(string itemId, List<LibraryItem> catalog)
        {
            LibraryItem foundItem = catalog.Find(item => item.itemId == itemId);
            if (foundItem != null)
            {
                ReturnItem(foundItem);
            }
            else
            {
                Console.WriteLine($"Item with ID {itemId} not found in catalog.");
            }
        }


        public virtual void displayMemberInfo()
        {
            Console.WriteLine($"Member ID: {_memberID}, Name: {_name}, Borrowed Items: {_borrowedItems.Count}/{_borrowLimit}");
            Console.WriteLine("Borrowed Items:");
            foreach (var item in _borrowedItems)
            {
                Console.WriteLine($"- {item.Title} (ID: {item.itemId})");
            }
        }
    }


        public class Book : LibraryItem
        {
            private string _author;

            public Book(string itemId, string title, string author) : base(itemId, title)
            {
                _author = author;
            }
            public override void DisplayInfo()
            {
                string status = _IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"[BOOK] ID: {itemId} | Title: {Title} | Author: {_author} | Status: {status}");
            }

        }

        public class Magzine : LibraryItem
        {
            private string _publisher;
            private int _issueNumber;
            public Magzine(string itemId, string title, string publisher, int issueNumber) : base(itemId, title)
            {
                _publisher = publisher;
                _issueNumber = issueNumber;
            }
            public override void DisplayInfo()
            {
                string status = _IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"[MAGZINE] ID: {itemId} | Title: {Title} | Publisher: {_publisher} | Status: {status}");
            }
        }

        public class DigitalMedia : LibraryItem
        {
            private string _format;
            private double _fileSizeMB;
            public DigitalMedia(string itemId, string title, string format, double fileSizeMB) : base(itemId, title)
            {
                _format = format;
                _fileSizeMB = fileSizeMB;
            }
            public override void DisplayInfo()
            {
                string status = _IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"[DIGITAL MEDIA] ID: {itemId} | Title: {Title} | Format: {_format} | File Size: {_fileSizeMB} MB | Status: {status}");
            }
        }


        // Dvd class removed; DVDs are represented using DigitalMedia with format "DVD"



        public class PremiumMember : Member
        {
            private double membershipFee;

            public PremiumMember(string memberId, string name, double fee) : base(memberId, name)
            {
                membershipFee = fee;
                _borrowLimit = 10;
            }
            public override void BorrowItem(LibraryItem item)
            {
                // Premium members can borrow any type of media
                if (_borrowedItems.Count < _borrowLimit && item._IsAvailable)
                {
                    item._IsAvailable = false;
                    _borrowedItems.Add(item);
                    Console.WriteLine($"{Name} Successfully borrowed {item.Title}");
                }
                else
                {
                    Console.WriteLine($"{Name} Cannot borrow {item.Title}. Either borrow limit reached or item is not available.");
                }
            }
            public override void displayMemberInfo()
            {
                base.displayMemberInfo();
                Console.WriteLine($"Membership Fee: ${membershipFee}");
            }

            public void AccessPremiumContent()
            {
                Console.WriteLine($"{Name} is accessing premium content.");
            }
        }

}



