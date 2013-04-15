using System.Collections.Generic;
using BellmanFord.Model;
using CuttingEdge;

namespace BellmanFord.View
{
    interface IRoutingTable
    {
        ReadOnlyDictionary<INamedObject, RoutingTableEntry> RoutingTable();
    }
}
