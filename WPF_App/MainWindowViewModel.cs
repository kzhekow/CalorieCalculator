using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalorieCounter;
using CalorieCounter.Contracts;
using WPF_App.Annotations;

namespace WPF_App
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int calories;

        private int carbs;

        private int fat;

        private int fiber;

        private string name;

        private int protein;

        private int sugar;

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnPropertyChanged();
            }
        }

        public int Calories
        {
            get => this.calories;
            set
            {
                this.calories = value;
                this.OnPropertyChanged();
            }
        }

        public int Protein
        {
            get => this.protein;
            set
            {
                this.protein = value;
                this.OnPropertyChanged();
            }
        }

        public int Carbs
        {
            get => this.carbs;
            set
            {
                this.carbs = value;
                this.OnPropertyChanged();
            }
        }

        public int Fat
        {
            get => this.fat;
            set
            {
                this.fat = value;
                this.OnPropertyChanged();
            }
        }

        public int Sugar
        {
            get => this.sugar;
            set
            {
                this.sugar = value;
                this.OnPropertyChanged();
            }
        }

        public int Fiber
        {
            get => this.fiber;
            set
            {
                this.fiber = value;
                this.OnPropertyChanged();
            }
        }

        public ICalorieCounterEngine CalorieCounterEngineInstance
        {
            get; set;
        }

        public MainWindowViewModel()
        {
            this.CalorieCounterEngineInstance = CalorieCounterEngine.Instance;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}