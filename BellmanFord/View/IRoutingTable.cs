using System.Collections.Generic;
using BellmanFord.Model;
using CuttingEdge;

namespace BellmanFord.View
{
    public interface IRoutingTable
    {
        ReadOnlyDictionary<INamedObject, RoutingTableEntry> RoutingTable();
    }
}
