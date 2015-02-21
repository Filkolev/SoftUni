namespace TheSlum.GameEngine
{
    using System;
    using GameObjects.Characters;
    using GameObjects.Items;

    class ExtendedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character;
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = (Team)Enum.Parse(typeof(Team), inputParams[5]);
            string type = inputParams[1];

            switch (type)
            {
                case "mage":
                    character = new Mage(id, x, y, team);
                    break;
                case "warrior":
                    character = new Warrior(id, x, y, team);
                    break;
                case "healer":
                default:
                    character = new Healer(id, x, y, team);
                    break;
            }

            characterList.Add(character);
        }

        protected new void AddItem(string[] inputParams)
        {
            string characterId = inputParams[1];
            Character character = characterList.Find(x => x.Id == characterId);

            string itemClass = inputParams[2];
            string itemId = inputParams[3];

            Item item;
            switch (itemClass)
            {
                case "axe":
                    item = new Axe(itemId);
                    break;
                case "shield":
                    item = new Shield(itemId);
                    break;
                case "pill":
                    item = new Pill(itemId);
                    break;
                case "injection":
                default:
                    item = new Injection(itemId);
                    break;
            }

            character.AddToInventory(item);
        }
    }
}
