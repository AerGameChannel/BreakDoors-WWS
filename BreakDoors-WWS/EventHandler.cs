using System;
using WW_SYSTEM;
using WW_SYSTEM.API;
using WW_SYSTEM.EventHandlers;
using WW_SYSTEM.Events;

namespace BreakDoors
{
    public class EventHandler: IEventHandlerAdminQuery
    {
        public Plugin plugin;
        public Plugin BreakDoors;

        public EventHandler(BreakDoors plugin)
        {
            this.plugin = plugin;
        }
        public void OnAdminQuery(AdminQueryEvent ev)
        {
            string[] array = ev.Query.Split(new char[]
            {
                    ' '
            });
            if (ev.Query.ToLower().StartsWith("bd"))
            {
                if (array.Length <= 1)
                {
                    ev.Output = "BreakDoors#Usage: bd <RemoteAdmin player id>";
                    ev.Successful = true;
                    ev.Handled = true;
                    return;
                }
                if (string.IsNullOrEmpty(array[1]))
                {
                    ev.Output = "BreakDoors#Usage: bd <RemoteAdmin player id>";
                    ev.Successful = true;
                    ev.Handled = true;
                    return;
                }
                if (array.Length > 1)
                {
                    try
                    {
                        if (!ev.Admin.IsPermitted(PlayerPermissions.PlayersManagement))
                        {
                            ev.Output = "BreakDoors#Not enough permissions";
                            ev.Successful = false;
                            ev.Handled = true;
                            return;
                        }
                        if (array.Length > 0)
                        {
                            if (array[1].ToLower().Contains("help"))
                            {
                                ev.Output = "BreakDoors#Usage: bd <RemoteAdmin player id>";
                                ev.Successful = true;
                                ev.Handled = true;
                                return;
                            }
                            else
                            {
                                    int id = int.Parse(array[1]);

                                Player pl = Server.Round.FindPlayerWithId(id);
                                if (pl != null && !pl.BreakDoors)
                                {
                                    pl.BreakDoors = true;

                                    ev.Output = "BreakDoors#Enabled BreakDoors for player " + pl.Nick;
                                    ev.Successful = true;
                                    ev.Handled = true;
                                    return;
                                }
                                else if (pl != null && pl.BreakDoors)
                                {
                                    pl.BreakDoors = false;

                                    ev.Output = "BreakDoors#Disabled BreakDoors for player " + pl.Nick;
                                    ev.Successful = true;
                                    ev.Handled = true;
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ev.Output = "BreakDoors#Error: " + ex;
                        ev.Successful = false;
                        ev.Handled = true;
                        return;
                    }
                }
            }
        }
    }
}  
