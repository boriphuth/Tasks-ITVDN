/*==============================================================*/
/* Database name:  STRIKERSOFT                                  */
/* DBMS name:      Sybase SQL Anywhere 10                       */
/* Created on:     5/2/2016 6:56:31 PM                          */
/*==============================================================*/

use master
go
drop database strikersoft;

/*==============================================================*/
/* Database: strikersoft                                        */
/*==============================================================*/
create database strikersoft;

use strikersoft
go
/*==============================================================*/
/* Table: doctors                                               */
/*==============================================================*/
create table doctors 
(
   id                   uniqueidentifier               not null,
   name                 nvarchar(32)                   null,
   constraint pk_doctors primary key clustered (id)
);

/*==============================================================*/
/* Table: patients                                              */
/*==============================================================*/
create table patients 
(
   id                   uniqueidentifier               not null,
   name                 nvarchar(32)                   null,
   age                  int                            null,
   currentdoctorid      uniqueidentifier               null,
   constraint pk_patients primary key clustered (id)
);

/*==============================================================*/
/* Table: registrcards                                          */
/*==============================================================*/
create table registrcards 
(
   id                   uniqueidentifier               not null,
   patientid            uniqueidentifier               null,
   doctorid             uniqueidentifier               null,
   diagnosise           nvarchar(32)                   not null,
   visitdate            datetime                       not null default getdate(),
   constraint pk_registrcards primary key clustered (id)
);

alter table patients
   add constraint fk_patients_reference_doctors foreign key (currentdoctorid)
      references doctors (id);

alter table registrcards
   add constraint fk_registrc_reference_patients foreign key (patientid)
      references patients (id)
      on update cascade
      on delete cascade;

alter table registrcards
   add constraint fk_registrc_reference_doctors foreign key (doctorid)
      references doctors (id)
      on update cascade
      on delete cascade;

