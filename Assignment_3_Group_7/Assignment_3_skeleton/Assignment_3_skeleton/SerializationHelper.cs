using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using ProblemDomain; // Required to resolve the User class

namespace Assignment_3_skeleton
{
    /// <summary>
    /// Implementation for binary serialization and deserialization of User objects.
    /// </summary>
    public class SerializationHelper
    {
        public static void SerializeUsers(List<User> users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        public static List<User> DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (List<User>)serializer.ReadObject(stream);
            }
        }
    }
}

