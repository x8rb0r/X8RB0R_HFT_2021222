// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Must be protected in order for it to be visible by inheriting classes.", Scope = "member", Target = "~F:Gallery.Repository.Repository`1.ctx")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Must be protected in order for it to be visible by inheriting classes.", Scope = "member", Target = "~F:Gallery.Repository.GenericRepository`1.ctx")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "@ symbol not related to locality", Scope = "member", Target = "~M:Gallery.Repository.PersonRepository.ChangeEmail(System.Int32,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1012:Abstract types should not have public constructors", Justification = "Constructor required for intitializing the DbContext class", Scope = "type", Target = "~T:Gallery.Repository.GenericRepository`1")]
