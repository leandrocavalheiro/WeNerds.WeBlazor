using Microsoft.AspNetCore.Components;
using WeNerds.WeBlazor.Models;

namespace WeNerds.WeBlazor.Components
{
    public partial class WeSidebarMenu : ComponentBase
    {
        [Parameter]
        public Menu Menu { get; set; }
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

        }
        private void LoadMenu(string currentLevel)
        {
            if (Menu is null || Menu.Items is null || Menu.Items.Count is 0)
                return;

            Menu.ChangeActiveItem(currentLevel);
            StateHasChanged();
        }
    }
}
