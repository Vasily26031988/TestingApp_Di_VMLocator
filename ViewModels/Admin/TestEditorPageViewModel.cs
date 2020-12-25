using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestingApp_Di_VMLocator.Models;

namespace TestingApp_Di_VMLocator.ViewModels.Admin
{
    public class TestEditorPageViewModel : BindableBase
    {
        public Test Test { get; set; }

        public TestEditorPageViewModel()
        {
            {
                //Test = new Test();
                Test = new Test
                {
                    Title = "На лживость",
                    Questions = new ObservableCollection<Question>
                    {
                        new Question
                        {
                            Text = "1. Кто сьел мою собаку?",
                            Answers = new ObservableCollection<Answer>
                            {
                                new Answer
                                {
                                    Text="Я"
                                },
                                new Answer
                                {
                                    Text="Ты",
                                    IsCorrect= true
                                }
                            }
                        },
                         new Question
                        {
                            Text = "2. Кто сьел моего кота?",
                            Answers = new ObservableCollection<Answer>
                            {
                                new Answer
                                {
                                    Text="Я",
                                    IsCorrect= true
                                },
                                new Answer
                                {
                                    Text="Ты"
                                }
                            }
                        }
                    }
                };
            };
        }

        
    }
}
