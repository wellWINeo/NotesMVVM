using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotesMVVM.Model
{
    [Table("Notes")]
    public class Note : INotifyPropertyChanged
    {
        // internal
        private string title;
        private string body;

        // external
        [Key]
        public int Id { get; set; }
        public string Title
        {
            get { return this.title;  }
            set
            {
                if (value != this.title)
                {
                    this.title = value;
                    OnPropertyChanged("title");
                }
            }
        }

        public string Body
        {
            get { return this.body; }
            set
            {
                if (value != this.body)
                {
                    this.body = value;
                    OnPropertyChanged("body");
                }
            }
        }

        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Note(string title, string body = "")
        {
            this.title = title;
            this.body = body;
            this.Date = DateTime.Now;
        }

        public Note() { }
    }
}
