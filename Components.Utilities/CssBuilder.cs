﻿using System;
using System.Text;

namespace Components.Utilities
{
    public class CssBuilder
    {
        private readonly StringBuilder sb;

        /// <summary>
        /// Creates a CssBuilder used to define conditional CSS classes used in a component.
        /// Call Build() to return the completed CSS Classes as a string. 
        /// </summary>
        public CssBuilder() => sb = new StringBuilder();

        /// <summary>
        /// Creates a CssBuilder used to define conditional CSS classes used in a component.
        /// Call Build() to return the completed CSS Classes as a string. 
        /// </summary>
        /// <param name="value"></param>
        public CssBuilder(string value) => sb = new StringBuilder(value);

        /// <summary>
        /// Adds a raw string to the builder that will be concatinated with the next class or value added to the builder.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>CssBuilder</returns>
        public CssBuilder AddValue(string value)
        {
            sb.Append(value);
            return this;
        }

        /// <summary>
        /// Adds a CSS Class to the builder with space seperator.
        /// </summary>
        /// <param name="value">CSS Class to add</param>
        /// <returns>CssBuilder</returns>
        public CssBuilder AddClass(string value) => AddValue(" ").AddValue(value);

        /// <summary>
        /// Adds a conditional CSS Class to the builder with space seperator.
        /// </summary>
        /// <param name="value">CSS Class to conditionally add.</param>
        /// <param name="when">Conditon in which the CSS Class is added.</param>
        /// <returns>CssBuilder</returns>
        public CssBuilder AddClass(string value, bool when = true) => when ? this.AddClass(value) : this;

        /// <summary>
        /// Adds a conditional CSS Class to the builder with space seperator.
        /// </summary>
        /// <param name="value">CSS Class to conditionally add.</param>
        /// <param name="when">Conditon in which the CSS Class is added.</param>
        /// <returns>CssBuilder</returns>
        public CssBuilder AddClass(string value, Func<bool> when = null) => this.AddClass(value, when());

        /// <summary>
        /// Finalize the completed CSS Classes as a string.
        /// </summary>
        /// <returns>string</returns>
        public string Build() => ToString();
        public override string ToString() => sb.ToString();

    }
}
