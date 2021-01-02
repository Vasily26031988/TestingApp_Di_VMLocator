using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp_Di_VMLocator.Models
{
    public class Test : BindableBase
    {
        public Guid Id { get; set; } = new Guid();

		public string Title { get; set; }

        public int QuestionCount { get; set; }

        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();
    }

    public class Question
    {
        public string Text { get; set; }
        public ObservableCollection<Answer> Answers { get; set; } = new ObservableCollection<Answer>();
    }
    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        
    }
}

