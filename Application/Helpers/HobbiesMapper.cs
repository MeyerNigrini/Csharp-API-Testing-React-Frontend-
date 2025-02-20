using Application.Models;
using Domain.Entities;

namespace Application.Helpers
{
    public static class HobbiesMapper
    {
        /// <summary>
        /// Maps a list of <see cref="HobbiesEntity"/> objects to a <see cref="HobbiesModel"/> object.
        /// </summary>
        /// <param name="hobbies">The list of hobbies data to be mapped.</param>
        /// <returns>A structured <see cref="HobbiesModel"/> object.</returns>
        public static HobbiesModel MapToHobbiesModel(List<HobbiesEntity> hobbies)
        {
            return new HobbiesModel
            {
                // Map the "Karate" section
                Karate = CreateSection(hobbies, "Karate"),

                // Map the "Gaming" section
                Gaming = CreateSection(hobbies, "Gaming")
            };
        }

        /// <summary>
        /// Creates a <see cref="SectionModel"/> object for a specific hobby section.
        /// </summary>
        /// <param name="hobbies">The list of hobbies data to search for the section.</param>
        /// <param name="title">The title of the section to create (e.g., "Karate", "Gaming").</param>
        /// <returns>
        /// A <see cref="SectionModel"/> object if the section is found; otherwise, <c>null</c>.
        /// </returns>
        private static SectionModel? CreateSection(List<HobbiesEntity> hobbies, string title)
        {
            // Find the hobby data for the specified title
            var hobby = hobbies.Find(h => h.Title == title);

            // If no data is found, return null
            if (hobby == null)
            {
                return null;
            }

            // Create and return a SectionModel object
            return new SectionModel
            {
                Title = title,
                Paragraph = hobby.Paragraph,
                Details = hobby.Details?
                    .Select(d => new KeyValuePairModel { Key = d.Key, Value = d.Value })
                    .ToList() ?? new List<KeyValuePairModel>() // Ensure the details list is never null
            };
        }
    }
}
