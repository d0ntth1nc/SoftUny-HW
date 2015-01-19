
namespace Animals
{
    abstract class Animal : ISound
    {
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public string Name { get; private set; }

        public Animal(string name, int age, Gender gender)
        {
            this.Age = age;
            this.Name = name;
            this.Age = age;
        }

        public abstract void ProduceSound();
    }
}
