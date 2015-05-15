﻿using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web.Routing;

namespace Geta.EPi.Extensions
{
    /// <summary>
    ///     LinkItem Extensions.
    /// </summary>
    public static class LinkItemExtensions
    {
        /// <summary>
        ///     Returns ContentReference for provided LinkItem if it is EPiServer content otherwise returns EmptyReference.
        /// </summary>
        /// <param name="source">Source LinkItem for which to return content reference.</param>
        /// <returns>Returns ContentReference for provided LinkItem if it is EPiServer content otherwise returns EmptyReference.</returns>
        public static ContentReference ToContentReference(this LinkItem source)
        {
            var content = source.ToContent();

            return content != null
                       ? content.ContentLink
                       : ContentReference.EmptyReference;
        }

        /// <summary>
        ///     Returns IContent for provided LinkItem if it is EPiServer content otherwise returns null.
        /// </summary>
        /// <param name="source">Source LinkItem for which to return content.</param>
        /// <returns>Returns IContent for provided LinkItem if it is EPiServer content otherwise returns null.</returns>
        public static IContent ToContent(this LinkItem source)
        {
            var urlBuilder = new UrlBuilder(source.Href);
            var resolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            return resolver.Route(urlBuilder);
        }
    }
}
