//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v12.1.1+6cdd561
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
    public class ServicesList
    {
        public Dictionary<string, List<Dictionary<string, string>>> allServices;

        public ServicesList()
        {
            allServices = new Dictionary<string, List<Dictionary<string, string>>>() {
                {"san_services", new List<Dictionary<string,string>>()},
                {"hnas_services", new List<Dictionary<string,string>>()},
            };
        }
    }

    // private IPublishedValueFallback _publishedValueFallback;
	// 	public Dictionary<string, List<Dictionary<string, string>>> services;

	// 	// ctor
	// 	public Services(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
	// 		: base(content, publishedValueFallback)
	// 	{
	// 		_publishedValueFallback = publishedValueFallback;
	// 		services = new Dictionary<string, List<Dictionary<string, string>>>() {
	// 			{"san_services", new List<Dictionary<string,string>>()},
	// 			{"hnas_services", new List<Dictionary<string,string>>()},
	// 		};
	// 	}
}
