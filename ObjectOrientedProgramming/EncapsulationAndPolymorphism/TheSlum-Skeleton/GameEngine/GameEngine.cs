using System;
using System.Linq;

namespace TheSlum.GameEngine
{
    public class GameEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            base.ExecuteCommand(inputParams);
            switch (inputParams[0])
            {
                case "create": CreateCharacter(inputParams);
                    break;
                case "add": AddItem(inputParams);
                    break;
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            if (inputParams.Length < 4)
            {
                throw new InvalidOperationException("Bad command!");
            }

            var character = this.characterList.FirstOrDefault(x => x.Id == inputParams[1]);
            if (character == default(Character))
            {
                throw new InvalidOperationException("There is no character with given id!");
            }

            var type = Type.GetType("TheSlum.GameItems." + inputParams[2], true, true);
            string id = inputParams[3];

            var item = (Item)Activator.CreateInstance(type, id);
            character.AddToInventory(item);
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            if (inputParams.Length < 6)
            {
                throw new InvalidOperationException("Bad command!");
            }
            if (this.characterList.Any(z => z.Id == inputParams[2]))
            {
                throw new InvalidOperationException("There is already character with this id!");
            }

            var type = Type.GetType("TheSlum.Characters." + inputParams[1], true, true);
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = inputParams[5] == "Red" ? Team.Red : Team.Blue;

            Character character =
                (Character)Activator.CreateInstance(type, id, x, y, team);
            this.characterList.Add(character);
        }
    }
}
