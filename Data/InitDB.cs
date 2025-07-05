using Microsoft.EntityFrameworkCore;
using ASPNET_006_Book_Vault.Models;

namespace ASPNET_006_Book_Vault.Data
{
    public static class InitDB
    {
        /*
            Dependency Injection (DI) is designed to work with instances of classes rather than static classes.
            This is because static classes and methods are associated with the type itself,
            and they cannot be instantiated or injected in the same way as instances of non-static classes.
        */
        public static void Initialize(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var ctx = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (ctx != null) SeedData(ctx, isProduction);
            }
        }

        private static void SeedData(AppDbContext ctx, bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("Applying Migrations...");
                try
                {
                    ctx.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (!ctx.Books.Any())
            {
                Console.WriteLine("========== Seeding Books Data ==========");
                ctx.Books.AddRange(
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        Description = "A powerful story of racial injustice and childhood innocence in the American South.",
                        Author = "Harper Lee",
                        Genre = "Fiction",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8228691-L.jpg"
                    },
                    new Book
                    {
                        Title = "1984",
                        Description = "A chilling dystopia where totalitarian surveillance crushes individual freedom.",
                        Author = "George Orwell",
                        Genre = "Science Fiction",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/1535610-L.jpg"
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        Description = "A witty critique of social class and romance in 19th-century England.",
                        Author = "Jane Austen",
                        Genre = "Romance",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8231996-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Great Gatsby",
                        Description = "The rise and fall of Jay Gatsby and the illusion of the American Dream.",
                        Author = "F. Scott Fitzgerald",
                        Genre = "Classic",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/7352161-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Hobbit",
                        Description = "Bilbo Baggins' journey to help dwarves reclaim their homeland from a dragon.",
                        Author = "J.R.R. Tolkien",
                        Genre = "Fantasy",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/6979861-L.jpg"
                    },
                    new Book
                    {
                        Title = "Moby-Dick",
                        Description = "A sea captain's obsessive quest for revenge against a giant white whale.",
                        Author = "Herman Melville",
                        Genre = "Adventure",
                        Rating = 4.2f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8100921-L.jpg"
                    },
                    new Book
                    {
                        Title = "Brave New World",
                        Description = "A future society driven by technology and consumerism but lacking emotion and freedom.",
                        Author = "Aldous Huxley",
                        Genre = "Dystopian",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8776047-L.jpg"
                    },
                    new Book
                    {
                        Title = "Jane Eyre",
                        Description = "An orphaned governess confronts love, secrets, and independence.",
                        Author = "Charlotte Brontë",
                        Genre = "Gothic",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8224151-L.jpg"
                    },
                    new Book
                    {
                        Title = "Crime and Punishment",
                        Description = "A psychological study of guilt and redemption in Tsarist Russia.",
                        Author = "Fyodor Dostoevsky",
                        Genre = "Philosophical",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8231857-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        Description = "A teen's journey through alienation and identity in post-war America.",
                        Author = "J.D. Salinger",
                        Genre = "Coming-of-Age",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8226191-L.jpg"
                    },
                    new Book
                    {
                        Title = "Little Women",
                        Description = "Four sisters navigate love, loss, and womanhood during the Civil War.",
                        Author = "Louisa May Alcott",
                        Genre = "Family",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8231851-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        Description = "A fellowship battles dark forces to destroy a powerful ring.",
                        Author = "J.R.R. Tolkien",
                        Genre = "Epic Fantasy",
                        Rating = 5.0f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8235237-L.jpg"
                    },
                    new Book
                    {
                        Title = "Frankenstein",
                        Description = "A scientist creates life but loses control over his monstrous creation.",
                        Author = "Mary Shelley",
                        Genre = "Horror",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8235104-L.jpg"
                    },
                    new Book
                    {
                        Title = "Dracula",
                        Description = "A group of people face the terror of an ancient vampire.",
                        Author = "Bram Stoker",
                        Genre = "Horror",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8315086-L.jpg"
                    },
                    new Book
                    {
                        Title = "Wuthering Heights",
                        Description = "A dark and passionate tale of love and revenge on the Yorkshire moors.",
                        Author = "Emily Brontë",
                        Genre = "Gothic",
                        Rating = 4.2f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8228697-L.jpg"
                    },
                    new Book
                    {
                        Title = "Fahrenheit 451",
                        Description = "In a future where books are banned, one man fights for knowledge.",
                        Author = "Ray Bradbury",
                        Genre = "Science Fiction",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/9254266-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Alchemist",
                        Description = "A young shepherd's journey to find his destiny and treasure.",
                        Author = "Paulo Coelho",
                        Genre = "Adventure",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8079256-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Picture of Dorian Gray",
                        Description = "A man trades his soul for eternal youth and beauty.",
                        Author = "Oscar Wilde",
                        Genre = "Philosophical",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8228698-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Chronicles of Narnia",
                        Description = "Children discover a magical world through a wardrobe and face dark forces.",
                        Author = "C.S. Lewis",
                        Genre = "Fantasy",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/7949256-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Kite Runner",
                        Description = "A poignant tale of friendship, betrayal, and redemption in Afghanistan.",
                        Author = "Khaled Hosseini",
                        Genre = "Drama",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8231991-L.jpg"
                    },
                    new Book
                    {
                        Title = "A Tale of Two Cities",
                        Description = "A gripping story of love and sacrifice set during the French Revolution.",
                        Author = "Charles Dickens",
                        Genre = "Historical Fiction",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8079416-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Brothers Karamazov",
                        Description = "A philosophical and spiritual exploration of morality, free will, and faith.",
                        Author = "Fyodor Dostoevsky",
                        Genre = "Classic",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232225-L.jpg"
                    },
                    new Book
                    {
                        Title = "Anna Karenina",
                        Description = "A tragic romance that exposes Russian aristocratic life.",
                        Author = "Leo Tolstoy",
                        Genre = "Romance",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232149-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Stranger",
                        Description = "A philosophical novel on absurdism and existentialism.",
                        Author = "Albert Camus",
                        Genre = "Philosophical",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8235025-L.jpg"
                    },
                    new Book
                    {
                        Title = "Don Quixote",
                        Description = "A comedic and satirical adventure of an aging knight and his loyal squire.",
                        Author = "Miguel de Cervantes",
                        Genre = "Adventure",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/7222246-L.jpg"
                    },
                    new Book
                    {
                        Title = "Les Misérables",
                        Description = "A sweeping epic of justice, redemption, and love in post-revolutionary France.",
                        Author = "Victor Hugo",
                        Genre = "Drama",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232004-L.jpg"
                    },
                    new Book
                    {
                        Title = "One Hundred Years of Solitude",
                        Description = "A multigenerational tale of the Buendía family in the town of Macondo.",
                        Author = "Gabriel García Márquez",
                        Genre = "Magical Realism",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232452-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Old Man and the Sea",
                        Description = "An aging fisherman struggles with a giant marlin in the Gulf Stream.",
                        Author = "Ernest Hemingway",
                        Genre = "Literary Fiction",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232066-L.jpg"
                    },
                    new Book
                    {
                        Title = "Slaughterhouse-Five",
                        Description = "A surreal account of World War II and time travel, reflecting trauma and absurdity.",
                        Author = "Kurt Vonnegut",
                        Genre = "Science Fiction",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232427-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Bell Jar",
                        Description = "A young woman's descent into mental illness in 1950s America.",
                        Author = "Sylvia Plath",
                        Genre = "Autobiographical Fiction",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8231856-L.jpg"
                    },
                    new Book
                    {
                        Title = "Beloved",
                        Description = "A haunting tale of slavery, motherhood, and memory.",
                        Author = "Toni Morrison",
                        Genre = "Historical Fiction",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232548-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Road",
                        Description = "A post-apocalyptic survival story between a father and his son.",
                        Author = "Cormac McCarthy",
                        Genre = "Post-Apocalyptic",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232554-L.jpg"
                    },
                    new Book
                    {
                        Title = "Life of Pi",
                        Description = "A young boy stranded at sea with a Bengal tiger learns to survive and believe.",
                        Author = "Yann Martel",
                        Genre = "Adventure",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8229781-L.jpg"
                    },
                    new Book
                    {
                        Title = "Gone with the Wind",
                        Description = "A Southern belle's survival during and after the American Civil War.",
                        Author = "Margaret Mitchell",
                        Genre = "Historical Romance",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232453-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Secret Garden",
                        Description = "A lonely girl finds friendship and healing through a hidden garden.",
                        Author = "Frances Hodgson Burnett",
                        Genre = "Children's Fiction",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8229879-L.jpg"
                    },
                    new Book
                    {
                        Title = "Rebecca",
                        Description = "A new wife is haunted by the memory of her husband's dead first wife.",
                        Author = "Daphne du Maurier",
                        Genre = "Gothic",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233001-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Time Machine",
                        Description = "A scientist travels into the future to witness humanity's fate.",
                        Author = "H.G. Wells",
                        Genre = "Science Fiction",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232165-L.jpg"
                    },
                    new Book
                    {
                        Title = "Persuasion",
                        Description = "An Englishwoman reconnects with her lost love after years apart.",
                        Author = "Jane Austen",
                        Genre = "Romance",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232037-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Call of the Wild",
                        Description = "A sled dog returns to his primal instincts in the Alaskan wilderness.",
                        Author = "Jack London",
                        Genre = "Adventure",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232148-L.jpg"
                    },
                    new Book
                    {
                        Title = "Catch-22",
                        Description = "A satirical war novel exposing the contradictions of bureaucracy and conflict.",
                        Author = "Joseph Heller",
                        Genre = "Satire",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232145-L.jpg"
                    },
                    new Book
                    {
                        Title = "Dune",
                        Description = "A desert planet, political intrigue, and a prophesied messiah shape this sci-fi epic.",
                        Author = "Frank Herbert",
                        Genre = "Science Fiction",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/9251666-L.jpg"
                    },
                    new Book
                    {
                        Title = "A Clockwork Orange",
                        Description = "A disturbing tale of youth violence and the battle between free will and control.",
                        Author = "Anthony Burgess",
                        Genre = "Dystopian",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232100-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Wind-Up Bird Chronicle",
                        Description = "A surreal journey through Tokyo’s hidden dimensions and personal trauma.",
                        Author = "Haruki Murakami",
                        Genre = "Magical Realism",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232558-L.jpg"
                    },
                    new Book
                    {
                        Title = "Norwegian Wood",
                        Description = "A nostalgic, emotional story of young love and loss.",
                        Author = "Haruki Murakami",
                        Genre = "Drama",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232667-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Name of the Wind",
                        Description = "A gifted young man's rise from poverty to the most powerful magician in the world.",
                        Author = "Patrick Rothfuss",
                        Genre = "Fantasy",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232566-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Night Circus",
                        Description = "Two young illusionists compete in a mysterious, magical circus.",
                        Author = "Erin Morgenstern",
                        Genre = "Fantasy",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232670-L.jpg"
                    },
                    new Book
                    {
                        Title = "Cloud Atlas",
                        Description = "Interconnected stories spanning time and space reveal humanity’s eternal cycles.",
                        Author = "David Mitchell",
                        Genre = "Literary Fiction",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232768-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Shadow of the Wind",
                        Description = "A boy discovers a mysterious book that changes the course of his life forever.",
                        Author = "Carlos Ruiz Zafón",
                        Genre = "Mystery",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232800-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Book Thief",
                        Description = "A young girl finds solace in books during Nazi Germany, narrated by Death.",
                        Author = "Markus Zusak",
                        Genre = "Historical Fiction",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232513-L.jpg"
                    },
                    new Book
                    {
                        Title = "All the Light We Cannot See",
                        Description = "A blind French girl and a German boy cross paths during WWII.",
                        Author = "Anthony Doerr",
                        Genre = "Historical Fiction",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232832-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Goldfinch",
                        Description = "A boy’s life is shaped by the theft of a famous painting in the aftermath of tragedy.",
                        Author = "Donna Tartt",
                        Genre = "Drama",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232806-L.jpg"
                    },
                    new Book
                    {
                        Title = "Big Little Lies",
                        Description = "Murder, gossip, and secrets unravel in a wealthy coastal town.",
                        Author = "Liane Moriarty",
                        Genre = "Thriller",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232951-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Girl on the Train",
                        Description = "An unreliable narrator entangles herself in a missing person case.",
                        Author = "Paula Hawkins",
                        Genre = "Thriller",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232934-L.jpg"
                    },
                    new Book
                    {
                        Title = "Gone Girl",
                        Description = "A husband's life unravels when his wife disappears under suspicious circumstances.",
                        Author = "Gillian Flynn",
                        Genre = "Psychological Thriller",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232953-L.jpg"
                    },
                    new Book
                    {
                        Title = "Educated",
                        Description = "A memoir of a woman who leaves her survivalist family and earns a PhD.",
                        Author = "Tara Westover",
                        Genre = "Memoir",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8941056-L.jpg"
                    },
                    new Book
                    {
                        Title = "Becoming",
                        Description = "Michelle Obama's inspiring journey from the South Side of Chicago to the White House.",
                        Author = "Michelle Obama",
                        Genre = "Biography",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/9279992-L.jpg"
                    },
                    new Book
                    {
                        Title = "Thinking, Fast and Slow",
                        Description = "An exploration of how we make decisions, by Nobel laureate Daniel Kahneman.",
                        Author = "Daniel Kahneman",
                        Genre = "Non-Fiction",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232755-L.jpg"
                    },
                    new Book
                    {
                        Title = "Sapiens: A Brief History of Humankind",
                        Description = "An engaging look at the history and future of the human species.",
                        Author = "Yuval Noah Harari",
                        Genre = "History",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232844-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Subtle Art of Not Giving a F*ck",
                        Description = "A counterintuitive guide to living a better life by focusing on what matters.",
                        Author = "Mark Manson",
                        Genre = "Self-Help",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/9281257-L.jpg"
                    },
                    new Book
                    {
                        Title = "Atomic Habits",
                        Description = "A practical guide to building good habits and breaking bad ones.",
                        Author = "James Clear",
                        Genre = "Self-Help",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/9878374-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Silent Patient",
                        Description = "A psychotherapist unravels the mystery behind a mute woman who murdered her husband.",
                        Author = "Alex Michaelides",
                        Genre = "Psychological Thriller",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10540562-L.jpg"
                    },
                    new Book
                    {
                        Title = "Where the Crawdads Sing",
                        Description = "A young girl grows up in isolation and becomes the prime suspect in a murder case.",
                        Author = "Delia Owens",
                        Genre = "Mystery",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10516356-L.jpg"
                    },
                    new Book
                    {
                        Title = "Circe",
                        Description = "A reimagining of the mythological witch who defies the gods to find her power.",
                        Author = "Madeline Miller",
                        Genre = "Mythology",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/9281057-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Song of Achilles",
                        Description = "A romantic retelling of Achilles and Patroclus in the backdrop of the Trojan War.",
                        Author = "Madeline Miller",
                        Genre = "Historical Fiction",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232675-L.jpg"
                    },
                    new Book
                    {
                        Title = "Project Hail Mary",
                        Description = "A lone astronaut must save humanity from extinction in this gripping sci-fi tale.",
                        Author = "Andy Weir",
                        Genre = "Science Fiction",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/11095296-L.jpg"
                    },
                    new Book
                    {
                        Title = "Artemis",
                        Description = "A smuggler in the first lunar city gets pulled into a high-stakes conspiracy.",
                        Author = "Andy Weir",
                        Genre = "Science Fiction",
                        Rating = 4.3f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232871-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Midnight Library",
                        Description = "A woman finds a magical library that lets her explore alternate versions of her life.",
                        Author = "Matt Haig",
                        Genre = "Fantasy",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10588261-L.jpg"
                    },
                    new Book
                    {
                        Title = "Verity",
                        Description = "A struggling writer uncovers dark secrets while ghostwriting a famous author’s biography.",
                        Author = "Colleen Hoover",
                        Genre = "Romantic Thriller",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/11224870-L.jpg"
                    },
                    new Book
                    {
                        Title = "It Ends with Us",
                        Description = "A woman confronts the painful truths of love, abuse, and resilience.",
                        Author = "Colleen Hoover",
                        Genre = "Romance",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10530565-L.jpg"
                    },
                    new Book
                    {
                        Title = "It Starts with Us",
                        Description = "The sequel to *It Ends with Us*, giving Atlas his voice and story.",
                        Author = "Colleen Hoover",
                        Genre = "Romance",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/11820996-L.jpg"
                    },
                    new Book
                    {
                        Title = "Reminders of Him",
                        Description = "A mother’s journey to redemption and rebuilding connections after prison.",
                        Author = "Colleen Hoover",
                        Genre = "Drama",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/11621555-L.jpg"
                    },
                    new Book
                    {
                        Title = "A Man Called Ove",
                        Description = "A grumpy old man’s life changes when a lively family moves next door.",
                        Author = "Fredrik Backman",
                        Genre = "Contemporary Fiction",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233035-L.jpg"
                    },
                    new Book
                    {
                        Title = "Anxious People",
                        Description = "A failed bank robbery turns into a hostage situation full of unexpected humor and heart.",
                        Author = "Fredrik Backman",
                        Genre = "Drama",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10527783-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Seven Husbands of Evelyn Hugo",
                        Description = "A legendary Hollywood actress tells the truth about her glamorous and scandalous life.",
                        Author = "Taylor Jenkins Reid",
                        Genre = "Historical Drama",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10630797-L.jpg"
                    },
                    new Book
                    {
                        Title = "Daisy Jones & The Six",
                        Description = "The rise and fall of a fictional 1970s rock band told in oral history format.",
                        Author = "Taylor Jenkins Reid",
                        Genre = "Fiction",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10518769-L.jpg"
                    },
                    new Book
                    {
                        Title = "Malibu Rising",
                        Description = "Four siblings throw a legendary party that ends in disaster and revelation.",
                        Author = "Taylor Jenkins Reid",
                        Genre = "Contemporary Fiction",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/11268759-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Paris Library",
                        Description = "A dual-timeline novel about love, sacrifice, and the power of books during WWII.",
                        Author = "Janet Skeslien Charles",
                        Genre = "Historical Fiction",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10824601-L.jpg"
                    },
                    new Book
                    {
                        Title = "Before We Were Strangers",
                        Description = "College sweethearts reconnect after fifteen years in this emotional second-chance romance.",
                        Author = "Renée Carlino",
                        Genre = "Romance",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232726-L.jpg"
                    },
                    new Book
                    {
                        Title = "November 9",
                        Description = "A young couple meets once a year, exploring fate, love, and loss.",
                        Author = "Colleen Hoover",
                        Genre = "Romance",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/10824640-L.jpg"
                    },
                    new Book
                    {
                        Title = "Ugly Love",
                        Description = "A passionate and painful story of a no-strings-attached relationship turned real.",
                        Author = "Colleen Hoover",
                        Genre = "Romance",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232834-L.jpg"
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        Description = "Rules for focused success in a distracted world.",
                        Author = "Cal Newport",
                        Genre = "Productivity",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8378576-L.jpg"
                    },
                    new Book
                    {
                        Title = "The 7 Habits of Highly Effective People",
                        Description = "Timeless lessons in personal change and leadership.",
                        Author = "Stephen R. Covey",
                        Genre = "Self-Help",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232463-L.jpg"
                    },
                    new Book
                    {
                        Title = "Start With Why",
                        Description = "Discover the power of purpose in leadership and life.",
                        Author = "Simon Sinek",
                        Genre = "Business",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232963-L.jpg"
                    },
                    new Book
                    {
                        Title = "Zero to One",
                        Description = "Startup lessons on building the future from scratch.",
                        Author = "Peter Thiel",
                        Genre = "Business",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232999-L.jpg"
                    },
                    new Book
                    {
                        Title = "Rich Dad Poor Dad",
                        Description = "A personal finance classic that challenges the way we think about money.",
                        Author = "Robert T. Kiyosaki",
                        Genre = "Finance",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/11110595-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Lean Startup",
                        Description = "How today’s entrepreneurs use continuous innovation to create radically successful businesses.",
                        Author = "Eric Ries",
                        Genre = "Startup",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232987-L.jpg"
                    },
                    new Book
                    {
                        Title = "Steve Jobs",
                        Description = "A revealing biography of Apple’s visionary co-founder.",
                        Author = "Walter Isaacson",
                        Genre = "Biography",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/7417432-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Art of War",
                        Description = "Ancient Chinese military strategy applied to modern conflict and leadership.",
                        Author = "Sun Tzu",
                        Genre = "Philosophy",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/7984916-L.jpg"
                    },
                    new Book
                    {
                        Title = "Maus",
                        Description = "A Holocaust graphic novel that portrays Jews as mice and Nazis as cats.",
                        Author = "Art Spiegelman",
                        Genre = "Graphic Novel",
                        Rating = 4.9f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233088-L.jpg"
                    },
                    new Book
                    {
                        Title = "Persepolis",
                        Description = "A memoir of growing up during and after the Islamic Revolution in Iran.",
                        Author = "Marjane Satrapi",
                        Genre = "Graphic Novel",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233089-L.jpg"
                    },
                    new Book
                    {
                        Title = "Watchmen",
                        Description = "A dark and complex superhero tale that deconstructs the myth of the vigilante.",
                        Author = "Alan Moore",
                        Genre = "Graphic Novel",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233090-L.jpg"
                    },
                    new Book
                    {
                        Title = "Elon Musk",
                        Description = "The real-life story of one of tech's most ambitious entrepreneurs.",
                        Author = "Ashlee Vance",
                        Genre = "Biography",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233091-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Fault in Our Stars",
                        Description = "Two teens with cancer fall in love while navigating pain and loss.",
                        Author = "John Green",
                        Genre = "Young Adult",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232094-L.jpg"
                    },
                    new Book
                    {
                        Title = "Looking for Alaska",
                        Description = "A boy goes to boarding school and meets the fascinating, troubled Alaska Young.",
                        Author = "John Green",
                        Genre = "Young Adult",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232095-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Giver",
                        Description = "In a colorless world, one boy is chosen to receive memories of humanity.",
                        Author = "Lois Lowry",
                        Genre = "Dystopian",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8232093-L.jpg"
                    },
                    new Book
                    {
                        Title = "Kafka on the Shore",
                        Description = "Two parallel stories blend reality, myth, and metaphor in Murakami’s dreamscape.",
                        Author = "Haruki Murakami",
                        Genre = "Magical Realism",
                        Rating = 4.7f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233039-L.jpg"
                    },
                    new Book
                    {
                        Title = "Blindness",
                        Description = "A city descends into chaos when an epidemic of sudden blindness spreads.",
                        Author = "José Saramago",
                        Genre = "Literary Fiction",
                        Rating = 4.5f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233041-L.jpg"
                    },
                    new Book
                    {
                        Title = "The Shadow Lines",
                        Description = "A richly textured novel exploring personal and national boundaries.",
                        Author = "Amitav Ghosh",
                        Genre = "Postcolonial Fiction",
                        Rating = 4.4f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233042-L.jpg"
                    },
                    new Book
                    {
                        Title = "The White Tiger",
                        Description = "A man narrates his rise from rural poverty to entrepreneurial success in India.",
                        Author = "Aravind Adiga",
                        Genre = "Satire",
                        Rating = 4.6f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233043-L.jpg"
                    },
                    new Book
                    {
                        Title = "Things Fall Apart",
                        Description = "A Nigerian warrior faces the clash between tradition and colonial change.",
                        Author = "Chinua Achebe",
                        Genre = "Classic",
                        Rating = 4.8f,
                        CoverUrl = "https://covers.openlibrary.org/b/id/8233044-L.jpg"
                    }
                );
                ctx.SaveChanges();
                Console.WriteLine("========== Books Data Seeding Successful ==========");
            }
            else
            {
                Console.WriteLine("Books Data Already Existed");
            }
        }
    }
}