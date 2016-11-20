using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Syroot.Dumb3D
{
    /// <summary>
    /// Represents the resources of an assembly and provides helper methods to read specific data from the embedded
    /// resources.
    /// </summary>
    public class ResourceLoader
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private Assembly _assembly;

        // ---- CONSTRUCTORS -------------------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLoader"/> class with the default resource namespace
        /// (the assembly name appended with &quot;.Resources&quot;, e.g. &quot;TestGame.Resources&quot;.).
        /// </summary>
        public ResourceLoader() : this(Assembly.GetCallingAssembly().GetName().Name + ".Resources")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLoader"/> class with the given resource namespace.
        /// </summary>
        /// <param name="resourceNamespace">The root namespace in which embedded resources reside.</param>
        public ResourceLoader(string resourceNamespace)
        {
            ResourceNamespace = resourceNamespace;

            // Cache the available resource names.
            _assembly = Assembly.GetCallingAssembly();
            ResourceNames = new ReadOnlyCollection<string>(_assembly.GetManifestResourceNames());
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the root namespace in which embedded resources reside.
        /// </summary>
        public string ResourceNamespace
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of available resource names.
        /// </summary>
        public ReadOnlyCollection<string> ResourceNames
        {
            get;
            private set;
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the bitmap from the resource with the specified name.
        /// </summary>
        /// <param name="resourceName">The name of the bitmap resource.</param>
        /// <returns>The bitmap resource.</returns>
        public Bitmap GetBitmap(string resourceName)
        {
            using (Stream stream = GetStream(resourceName))
            {
                return (Bitmap)Image.FromStream(stream);
            }
        }

        /// <summary>
        /// Gets the icon from the resource with the specified name.
        /// </summary>
        /// <param name="resourceName">The name of the icon resource.</param>
        /// <returns>The icon resource.</returns>
        public Icon GetIcon(string resourceName)
        {
            using (Stream stream = GetStream(resourceName))
            {
                return new Icon(stream);
            }
        }

        /// <summary>
        /// Gets the string from the resource with the specified name.
        /// </summary>
        /// <param name="resourceName">The name of the text file resource.</param>
        /// <returns>The text file resource contents.</returns>
        public string GetString(string resourceName)
        {
            using (Stream stream = GetStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Gets the stream from the resource with the specified name.
        /// </summary>
        /// <param name="resourceName">The name of the resource.</param>
        /// <returns>The streamed resource contents.</returns>
        public Stream GetStream(string resourceName)
        {
            // Check if the resource is available in the assembly and return a stream if possible.
            resourceName = ResourceNamespace + "." + resourceName;
            if (ResourceNames.Contains(resourceName))
            {
                return _assembly.GetManifestResourceStream(resourceName);
            }
            throw new InvalidDataException("Resource \"" + resourceName + "\" not found.");
        }
    }
}
