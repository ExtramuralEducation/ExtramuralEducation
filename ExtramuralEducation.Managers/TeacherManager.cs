using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Models;
using ExtramuralEducation.Repository.Contracts;

namespace ExtramuralEducation.Managers
{
    public class TeacherManager : ITeacherManager
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherManager(IRepository<Teacher> teacherRepository)
        {
            this._teacherRepository = teacherRepository;
        }


        public Teacher GetById(long teacherId)
        {
            return this._teacherRepository.Get(teacherId);
        }

        public Teacher GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeacherByInstitute(long institutionId)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void Deleteteacher(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
