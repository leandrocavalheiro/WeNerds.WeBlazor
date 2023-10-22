using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components
{
    public partial class WeSidebarMenu
    {
        protected override void OnInitialized()
        {           
            InitializeMenu();
            LoadMenu("");            
        }
        public WeSidebarMenu()
        {
        }

        private void InitializeMenu()
        {
            _menu = new Menu();
            _item = _menu.AddMenuItem("Cadastros", "home", "");
            _menu.AddChildrenItem(_item, "Heróis", "corporate_fare", "counter");
            _menu.AddChildrenItem(_item, "Vilões", "student", "counter");
            _menu.AddChildrenItem(_item, "Quadrinhos", "corporate_fare", "counter");

            _item = _menu.AddMenuItem("Relatórios", "lab_profile", "");
            _menu.AddChildrenItem(_item, "Teste", "lab_profile", "fetchdata");

            _menu.Items = _menu.Items.OrderBy(p => p.Level).ToList();
        }
        private void LoadMenu(string currentLevel)
        {
            if (_menu == null || _menu.Items == null || _menu.Items.Count == 0)
                return;

            _menu.ChangeActiveItem(currentLevel);
            StateHasChanged();
        }
    }
}
