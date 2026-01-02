using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecureNotes
{
    /// <summary>
    /// Provide Json Service like convert Note to Json and Json to Note
    /// </summary>
    internal class JsonService
    {
        public static string? NotetoJson(Note note)
        {
            try
            {
                string json = JsonSerializer.Serialize(note);
                return json;
            }
            catch 
            {
                return null;
            }
        }

        public static Note? JsontoNote(string json)
        {
            try
            {
                Note note = JsonSerializer.Deserialize<Note>(json);

                return note;
            }
            catch 
            {
                return null; 
            }
        }
    }
}
