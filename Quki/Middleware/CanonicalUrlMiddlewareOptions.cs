// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


namespace Middleware.CanonicalURL
{
    /// <summary>
    /// Options for CanonicalUrlConfigurations
    /// </summary>
    public class CanonicalURLMiddlewareOptions
    {
        /// <summary>
        /// A flag that tell the middlware if it should make the urls lowercase
        /// </summary>
        public bool EnforceLowerCaseUrls { get; set; }

        /// <summary>
        /// A flag the represents if the QUeryString of the url is case sensitive
        /// and should not be altered
        /// </summary>
        public bool QueryStringCaseSensitive { get; set; }

        /// <summary>
        /// A flag that represents if the middleware should remove the trailing
        /// slash from the middleware
        /// </summary>
        public bool RemoveTrailingSlash { get; set; }

        public CanonicalURLMiddlewareOptions(){}

    }
}