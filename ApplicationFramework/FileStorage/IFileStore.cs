using ApplicationFramework.FileStorage.Request;
using ApplicationFramework.FileStorage.Response;
using System.IO;

namespace ApplicationFramework.FileStorage
{
    /// <summary>
    /// Interface defining how to interact with a generic file storage system
    /// </summary>
    public interface IFileStore
    {
        /// <summary>
        /// Deletes a file from the file storage.
        /// </summary>
        /// <param name="deleteFileRequest"></param>
        /// <returns></returns>
        DeleteFileResponse Delete(DeleteFileRequest deleteFileRequest);

        /// <summary>
        /// Saves a file to the file storage
        /// </summary>
        /// <param name="saveRequest"></param>
        /// <returns></returns>
        SaveFileResponse Save(SaveFileRequest saveRequest);

        /// <summary>
        /// Loads a file from the file storage
        /// </summary>
        /// <param name="loadFileRequest"></param>
        /// <returns></returns>
        LoadFileResponse Load(LoadFileRequest loadFileRequest);

        /// <summary>
        /// Loads a file into a memory stream
        /// </summary>
        /// <param name="loadFileRequest"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        LoadFileResponse LoadStream(LoadFileRequest loadFileRequest, Stream stream);
    }
}
