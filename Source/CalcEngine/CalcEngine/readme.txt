////////////////////////////////////////////////////////////////
//
// CalcEngine
// A Calculation Engine for .NET
//
////////////////////////////////////////////////////////////////


----------------------------------------------------------------
Version 1.0.0.2		Aug 2011

- TEXT function now uses CurrentCulture instead of InvariantCulture
	note: InvariantCulture does a weird job with currency formats!

----------------------------------------------------------------
Version 1.0.0.1		Aug 2011

- Fixed BindingExpression to update the DataContext when the 
  expression is fetched from the cache.

- Honor CultureInfo.TextInfo.ListSeparator
	so in US systems you would write "Sum(123.4, 567.8)"
	and in DE systems you would write "Sum(123,4; 567,8)"

- Changed default CultureInfo to InvariantCulture
	to make the component deterministic by default

- Improved Expression comparison logic
	both expressions should be of the same type

----------------------------------------------------------------
Version 1.0.0.0		Aug 2011

- First release on CodeProject:
	http://www.codeproject.com/KB/recipes/CalcEngine.aspx