using ContactList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList
{
    public static class ContactListExtensions
    {
        public static void EnsureSeedDataForContext(this ContactContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }

            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    FirstName = "Luka",
                    LastName = "Lukic",
                    Address = "Ulica 1",
                    Bookmarked = false,

                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            ContactTag = "Prijatelj"
                        },
                        new Tag()
                        {
                            ContactTag = "Susjed"
                        }
                    },
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            ContactEmail = "luka.lukic@mail.hr"
                        },
                         new Email()
                        {
                            ContactEmail = "luka.lukic0@mail.hr"
                        }
                    },
                    Numbers = new List<Number>()
                    {
                        new Number()
                        {
                            ContactNumber = 1234567891
                        },
                        new Number()
                        {
                            ContactNumber = 1234567811
                        }
                    }
                },
                new Contact()
                {
                    FirstName = "Marko",
                    LastName = "Markic",
                    Address = "Ulica Mira",
                    Bookmarked = true,

                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            ContactTag = "Kolega"
                        },
                        new Tag()
                        {
                            ContactTag = "Cageball"
                        }
                    },
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            ContactEmail = "marko.markic@mail.hr"
                        },
                         new Email()
                        {
                            ContactEmail = "marko.markic1@gmail.hr"
                        }
                    },
                    Numbers = new List<Number>()
                    {
                        new Number()
                        {
                            ContactNumber = 1334567891
                        },
                        new Number()
                        {
                            ContactNumber = 1224567811
                        }
                    }
                },
                 new Contact()
                {
                    FirstName = "Ivan",
                    LastName = "Ivic",
                    Address = "Nova ulica 10",
                    Bookmarked = false,

                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            ContactTag = "Kolega"
                        },
                        new Tag()
                        {
                            ContactTag = "Prijatelj"
                        }
                    },
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            ContactEmail = "ivan.ivic@mail.hr"
                        },
                         new Email()
                        {
                            ContactEmail = "ivan.ivic1@gmail.hr"
                        }
                    },
                    Numbers = new List<Number>()
                    {
                        new Number()
                        {
                            ContactNumber = 1334567111
                        },
                        new Number()
                        {
                            ContactNumber = 1224563811
                        }
                    }
                },
                  new Contact()
                {
                    FirstName = "Petar",
                    LastName = "Peric",
                    Address = "Petrova ulica",
                    Bookmarked = true,

                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            ContactTag = "Prijatelj"
                        },
                        new Tag()
                        {
                            ContactTag = "Airsoft"
                        }
                    },
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            ContactEmail = "petar.peric@mail.hr"
                        },
                         new Email()
                        {
                            ContactEmail = "petar.peric1@gmail.hr"
                        }
                    },
                    Numbers = new List<Number>()
                    {
                        new Number()
                        {
                            ContactNumber = 1334557891
                        },
                        new Number()
                        {
                            ContactNumber = 1255567811
                        }
                    }
                }
            };

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
}
