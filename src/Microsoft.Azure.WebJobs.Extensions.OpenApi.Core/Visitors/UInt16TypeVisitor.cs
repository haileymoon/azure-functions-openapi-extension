using System;
using System.Collections.Generic;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Visitors
{
    /// <summary>
    /// This represents the type visitor for <see cref="ushort"/>.
    /// </summary>
    public class UInt16TypeVisitor : TypeVisitor
    {
        /// <inheritdoc />
        public UInt16TypeVisitor(VisitorCollection visitorCollection)
            : base(visitorCollection)
        {
        }

        /// <inheritdoc />
        public override bool IsVisitable(Type type)
        {
            var isVisitable = this.IsVisitable(type, TypeCode.UInt16) &&
                              !type.IsUnflaggedEnumType();

            return isVisitable;
        }

        /// <inheritdoc />
        public override void Visit(IAcceptor acceptor, KeyValuePair<string, Type> type, NamingStrategy namingStrategy, params Attribute[] attributes)
        {
            this.Visit(acceptor, name: type.Key, title: null, dataType: "integer", dataFormat: null, attributes: attributes);
        }

        /// <inheritdoc />
        public override bool IsParameterVisitable(Type type)
        {
            var isVisitable = this.IsVisitable(type);

            return isVisitable;
        }

        /// <inheritdoc />
        public override OpenApiSchema ParameterVisit(Type type, NamingStrategy namingStrategy)
        {
            return this.ParameterVisit(dataType: "integer", dataFormat: null);
        }

        /// <inheritdoc />
        public override bool IsPayloadVisitable(Type type)
        {
            var isVisitable = this.IsVisitable(type);

            return isVisitable;
        }

        /// <inheritdoc />
        public override OpenApiSchema PayloadVisit(Type type, NamingStrategy namingStrategy)
        {
            return this.PayloadVisit(dataType: "integer", dataFormat: null);
        }
    }
}
