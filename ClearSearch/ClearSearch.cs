using System.Windows.Forms;
using Eplan.EplApi.Scripting;

public class ClearS {
    [DeclareMenu]
    public void MenuFunction () {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu ();
        oMenu.AddMenuItem ("Show results (empty)", "ClearSearchAct", "Show serach results (empty list)", 35044, 0, true, true);
    }

    [DeclareAction ("ClearSearchAct")]
    public void ClearSearch () {
        CommandLineInterpreter oCLI = new CommandLineInterpreter ();
        oCLI.Execute ("XSeShowSearchResultsAction");
        oCLI.Execute ("GfDlgMgrActionIGfWind /function:DeleteAll");
    }

}