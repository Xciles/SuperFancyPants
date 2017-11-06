namespace ExceptionDemo
{
    public class Game
    {
        public Room _room { get; set; }

        public Game()
        {
            _room = new Room();
        }

        public void SetupRoom()
        {
            _room.SetItems();
        }

        public void PrintItemsInChestInRoom(int withValue)
        {
            _room.PrintItemValue(withValue);
        }
    }
}