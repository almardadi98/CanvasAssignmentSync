using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts
{
    public class CourseDto
    {
        public string? Name { get; init; }

        public string Id { get; init; }

        public string Uuid { get; init; }

        public DateTime StartAt { get; init; }

    }
}
