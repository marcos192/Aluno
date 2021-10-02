﻿using Alunos.Context;
using Alunos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Alunos.Controllers
{
    public class AlunosController : Controller
    {

        private EFContext context = new EFContext();


        // GET: Alunos
        public ActionResult Index()
        {
            return View(context.alunos.OrderBy(a => a.Nome));
        }

        // GET: Alunos
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Aluno alunos)
            {
            context.alunos.Add(alunos);
            context.SaveChanges();
            return RedirectToAction("Index");
            }

        public ActionResult Edit(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Aluno aluno = context.alunos.Find(id);
            if (aluno == null)
                {
                return HttpNotFound();
                }
            return View(aluno);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
            {
            if (ModelState.IsValid)
                {
                context.Entry(aluno).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(aluno);
            }

        public ActionResult Details(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Aluno aluno = context.alunos.Find(id);
            if (aluno == null)
                {
                return HttpNotFound();
                }
            return View(aluno);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Aluno aluno)
            {
            if (ModelState.IsValid)
                {
                context.Entry(aluno).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(aluno);
            }

        public ActionResult Delete(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Aluno aluno = context.alunos.Find(id);
            if (aluno == null)
                {
                return HttpNotFound();
                }
            return View(aluno);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
            {
            Aluno aluno = context.alunos.Find(id);
            context.alunos.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
        }
    }
