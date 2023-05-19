using BuberDinner.Domain.Menus;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand
   (
       Guid HostId,
       string Name,
       string Description,
       List<MenuSectioncCommand> Sections
       ) : IRequest<ErrorOr<Menu>>;

    public record MenuSectioncCommand
    (
        string Name,
        string Description,
        List<MenuItemCommand> Items
        );

    public record MenuItemCommand
   (
       string Name,
       string Description
        );
}
