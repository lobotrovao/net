namespace Application.View
{
    /// <summary>
    /// Main View.
    /// </summary>
    public class EndpointManagerMainView
    {
        private readonly EndpointInsertView insertView;
        private readonly EndpointEditView editView;
        private readonly EndpointDeleteView deleteView;
        private readonly EndpointListView listView;
        private readonly EndpointFindView findView;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointManagerMainView"/> class.
        /// </summary>
        /// <param name="insertView">Insert View.</param>
        /// <param name="editView">Edit View.</param>
        /// <param name="deleteView">Delete View.</param>
        /// <param name="listView">List View.</param>
        /// <param name="findView">Find View.</param>
        public EndpointManagerMainView(
            EndpointInsertView insertView,
            EndpointEditView editView,
            EndpointDeleteView deleteView,
            EndpointListView listView,
            EndpointFindView findView)
        {
            this.insertView = insertView;
            this.editView = editView;
            this.deleteView = deleteView;
            this.listView = listView;
            this.findView = findView;
        }

        /// <summary>
        /// Show main operations.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ShowMainMenu()
        {
            Console.WriteLine("ENDPOINT MANAGER");
            Console.WriteLine("1 - Insert new endpoint");
            Console.WriteLine("2 - Edit existing endpoint");
            Console.WriteLine("3 - Delete existing endpoint");
            Console.WriteLine("4 - List all endpoints");
            Console.WriteLine("5 - Find endpoint by serial number");
            Console.WriteLine("6 - Exit");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Select one option:");
            var option = Console.ReadLine();

            try
            {
                switch (option)
                {
                    case "1":
                        await insertView.Show();
                        await BackToMainMenu();
                        break;

                    case "2":
                        await editView.Show();
                        await BackToMainMenu();
                        break;

                    case "3":
                        await deleteView.Show();
                        await BackToMainMenu();
                        break;

                    case "4":
                        await listView.Show();
                        await BackToMainMenu();
                        break;

                    case "5":
                        await findView.Show();
                        await BackToMainMenu();
                        break;
                    case "6":
                        Exit();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation!");
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error:" + ex.Message);

                await BackToMainMenu();
            }
        }

        /// <summary>
        /// Ask if wants go to main menu.
        /// </summary>
        /// <param name="method">Method to be executed.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task BackToMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Would you like to back to main menu? Y/N");
            Console.WriteLine("IF N THE APPLICATION WILL BE CLOSED!");
            var option = Console.ReadLine().ToUpper();

            switch (option)
            {
                case "Y":
                    Console.Clear();
                    await ShowMainMenu();
                    break;
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        public void Exit()
        {
            Console.WriteLine("Are you sure that you want exit application? Y/N");
            var option = Console.ReadLine().ToUpper();

            switch (option)
            {
                case "Y":
                    Environment.Exit(0);
                    break;
                case "N":
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }
        }
    }
}
