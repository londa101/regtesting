﻿using System;
using RegTesting.Tests.Core;

namespace RegTesting.Tests.Core
{
	/// <summary>
	/// A Factory for the Typesloader
	/// </summary>
	public class TypesLoaderFactory : MarshalByRefObject , ITypesLoaderFactory
	{
		/// <summary>
		/// Create a Factory
		/// </summary>
		/// <param name="assemblyFile">Our Assembly</param>
		/// <param name="typeName">the type to create</param>
		/// <param name="constructArgs">constructor arguments</param>
		/// <returns>A new class of type typeName</returns>
		public ITypesLoader Create(string assemblyFile, string typeName,
								object[] constructArgs)
		{
			//Ignore all errors and return null in error case.
			try
			{
				return (ITypesLoader)Activator.CreateInstance(assemblyFile, typeName, constructArgs).Unwrap();
			}
			catch (InvalidCastException)
			{
				//Try to load and cast of a non ITypesLoader.
			}
			catch (MissingMethodException)
			{
				//No matching public constructor was found.
			}
			catch (TypeLoadException)
			{
				//typename was not found in assemblyFile.
			}
			catch (System.IO.FileNotFoundException)
			{
				//assemblyFile was not found.
			}
			catch (MethodAccessException)
			{
				// The caller does not have permission to call this constructor.
			}
			catch (MemberAccessException)
			{
				//Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism.
			}
			catch (System.Reflection.TargetInvocationException)
			{
				//The constructor, which was invoked through reflection, threw an exception.
			}
			catch (NotSupportedException)
			{
				//activationAttributes is not an empty array, and the type being created does not derive from System.MarshalByRefObject.
			}
			catch (System.Security.SecurityException)
			{
				//The caller does have the required System.Security.Permissions.FileIOPermission.
			}
			catch (BadImageFormatException)
			{
				//assemblyFile is not a valid assembly. -or- 
				//The common language runtime (CLR) version 2.0 or later is currently loaded,
				//and assemblyName was compiled for a version of the CLR that is later than the currently loaded version.
				//Note that the .NET Framework versions 2.0, 3.0, and 3.5 all use CLR version 2.0.
			}
			return null;



		}
	}
}
