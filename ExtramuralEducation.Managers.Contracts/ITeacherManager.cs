using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtramuralEducation.Models;

namespace ExtramuralEducation.Managers.Contracts
{
    public interface ITeacherManager
    {
        Teacher GetById(long teacherId);

        Teacher GetByUserId(Guid userId);

        IEnumerable<Teacher> GetTeacherByInstitute(long institutionId);

        void AddTeacher(Teacher entity);

        void Deleteteacher(long Id);
    }
}
