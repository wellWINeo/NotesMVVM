using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using NotesMVVM.Model;
using NotesMVVM.Services.Commands;
using System.Windows;

namespace NotesMVVM.ViewModel
{
    class NotesViewModel : INotifyPropertyChanged
    {
        private Note selectedNote;
        public ObservableCollection<Note> Notes { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        var note = new Note("New note...");
                        this.Notes.Insert(0, note);
                        this.SelectedNote = note;
                    }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        this.Notes.Remove(this.SelectedNote);
                        this.SelectedNote = null;
                    }));
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
                        this.Notes.Move(Notes.IndexOf(SelectedNote), 0);
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
                        this.Notes.Move(Notes.IndexOf(SelectedNote), 
                            Notes.Count - 1);
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

        public NotesViewModel()
        {
            this.Notes = new ObservableCollection<Note>()
            {
                new Note("Yet"),
                new Note("Another"),
                new Note("new note")
            };
        }

    }
}
