using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using NotesMVVM.Model;
using System.Windows;
using NotesMVVM;

using System.Data.Entity;

namespace NotesMVVM.ViewModel
{
    class NotesViewModel : INotifyPropertyChanged
    {
        private Note selectedNote;

        private ApplicationContext db;

        private IEnumerable<Note> notes;
        public IEnumerable<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged("Notes");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                    {
                        var note = new Note("New note...");
                        db.Notes.Add(note);
                        db.SaveChanges();
                    });
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??= new RelayCommand(obj =>
                    {
                        db.Notes.Remove(SelectedNote);
                        SelectedNote = null;
                        db.SaveChanges();
                    });
            }
        }

        private RelayCommand toTopCommand;
        public RelayCommand ToTopCommand
        {
            get
            {
                return toTopCommand ??
                    (toTopCommand = new RelayCommand(obj =>
                    {
                        //this.Notes.Move(Notes.IndexOf(SelectedNote), 0);
                    }));
            }
        }

        private RelayCommand toBottomCommand;
        public RelayCommand ToBottomCommand
        {
            get
            {
                return toBottomCommand ??
                    (toBottomCommand= new RelayCommand(obj =>
                    {
                        //this.Notes.Move(Notes.IndexOf(SelectedNote), 
                        //    Notes.Count - 1);
                    }));
            }
        }

        public Note SelectedNote
        {
            get { return this.selectedNote; }
            set
            {
                if (value != this.selectedNote)
                {
                    db.SaveChanges();
                    this.selectedNote = value;
                    OnPropertyChanged("selectedNote");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        // Constructor
        public NotesViewModel()
        {
            db = new ApplicationContext();
            db.Notes.Load();
            Notes = db.Notes.Local.ToBindingList();
        }

    }
}
