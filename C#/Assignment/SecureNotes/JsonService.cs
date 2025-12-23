using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecureNotes
{
    internal class JsonService
    {
        public static string NotetoJson(Note note)
        {
            string json = JsonSerializer.Serialize(note);

            return json;
        }

        public static Note JsontoNote(string json)
        {
            Note note = JsonSerializer.Deserialize<Note>(json);

            return note;
        }
    }
}
