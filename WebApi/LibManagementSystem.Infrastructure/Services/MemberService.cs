using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using LibManagementSystem.Infrastructure.DTO;
using LibraryManagementSystem.Domain.Entities;

namespace LibManagementSystem.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IEnumerable<MemberDto>> GetMembers()
        {
            var members = await _unitOfWork.MemberRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public async Task<MemberDto> CreateMember(MemberDto dto)
        {
            var member = await _unitOfWork.MemberRepository.FirstOrDefault(x => x.FirstName == dto.FirstName &&
                x.LastName == dto.LastName && x.PhoneNumber == dto.PhoneNumber);

            if (member is not null)
            {
                throw new Exception("Members with this data already exist.");
            }

            await _unitOfWork.MemberRepository.AddAsync(_mapper.Map<Member>(dto));
            await _unitOfWork.Commit();

            return dto;
        }
    }
}