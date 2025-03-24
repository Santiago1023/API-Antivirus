INSERT INTO public.institutions(
	name, ubication, url_generalidades, url_oferta_academica, url_bienestar, url_admision, logo)
	VALUES (
	'Institución Universitaria de Envigado', 'Envigado, Antioquia',
	'https://www.iue.edu.co/', 
	'https://www.iue.edu.co/?page_id=3173', 
	'https://www.iue.edu.co/?page_id=5126',
	'https://www.iue.edu.co/la-iue/guias-de-inscripcion/',
	'https://www.iue.edu.co/wp-content/uploads/2023/08/logo-iue-envigado.svg'
	),
	('Politécnico Jaime Isaza Cadavid', 'Medellín, Antioquia',
	'https://www.politecnicojic.edu.co/',
	'https://www.politecnicojic.edu.co/profesionales/#oferta-academica=pregrados',
	'https://www.politecnicojic.edu.co/presentacionbienestar',
	'https://www.politecnicojic.edu.co/aspirantes',
	'https://upload.wikimedia.org/wikipedia/commons/f/fb/Politecnico.png'
	),
	('Institución Universitaria Pascual Bravo', 'Medellín, Antioquia',
	'https://pascualbravo.edu.co/',
	'https://pascualbravo.edu.co/pregrados/',
	'https://pascualbravo.edu.co/academico/bienestar', 
	'https://sicau.pascualbravo.edu.co/SICAU/Aspirante/Login.jsp',
	'https://www.acofi.edu.co/wp-content/uploads/2014/12/INSTITUCION-UNIVERSITARIA-PASCUAL-BRAVO.jpg'
	),
	('Institución Universitaria Colegio Mayor de Antioquia', 'Medellín, Antioquia',
	'https://www.colmayor.edu.co/',
 	'https://www.colmayor.edu.co/programas/',
	'https://www.colmayor.edu.co/bienestar/',
 	'https://www.colmayor.edu.co/admisiones/contacto-para-admisiones/',
	'https://www.elempleo.com/co/sitio-empresarial/CompanySites/colegio-mayor-antioquia/resources/images/logo-social.png'
	),
	('Tecnológico de Antioquia', 'Medellín, Antioquia',
	'https://inscripcionestdea.com/', 
	'https://www.tdea.edu.co/index.php/bienestar',
	'https://www.tdea.edu.co/index.php/bienetar/bienestar',
	'https://www.tdea.edu.co/index.php/micrositios/aspirantes',
	'https://sibcolombia.net/wp-content/uploads/2020/05/TdeA-1.png'
	),
	('Universidad de Antioquia', 'Medellín, Antioquia',
	'https://www.udea.edu.co/',
	'https://www.udea.edu.co/wps/portal/udea/web/inicio/programas-academicos',
	'https://www.udea.edu.co/wps/portal/udea/web/inicio/bienestar',
	'https://www.udea.edu.co/wps/portal/udea/web/inicio/admisiones',
	'https://i.ytimg.com/vi/25J3F6WBj44/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLBvQCKjCYR29yIcdD2K54b1tzYV8g'
	),
	('Universidad Nacional de Colombia - Sede Medellín', 'Medellín, Antioquia',
	'https://www.medellin.unal.edu.co/',
	'https://www.medellin.unal.edu.co/programas.html',
	'https://www.medellin.unal.edu.co/bienestar-universitario.html',
	'https://www.medellin.unal.edu.co/admisiones.html',
	'https://www1.funcionpublica.gov.co/documents/28587425/41589060/logo-Universidad-Nacional.png/92343759-b2d7-7df3-4425-efa3337f2da7?t=1671747619326'
	),
	('Universidad EAFIT', 'Medellín, Antioquia',
	'https://www.eafit.edu.co/',
	'https://www.eafit.edu.co/programas-academicos',
	'https://www.eafit.edu.co/bienestar-universitario',
	'https://www.eafit.edu.co/inscripciones-y-admisiones',
	'https://mbainternationalbusiness.net/wp-content/uploads/2015/04/Univ.-EAFIT-Logo.jpg'
	),
	('Universidad Pontificia Bolivariana', 'Medellín, Antioquia',
	'https://www.upb.edu.co/', 
	'https://www.upb.edu.co/es/pregrados',
	'https://www.upb.edu.co/es/bienestar',
	'https://www.upb.edu.co/es/admisiones',
	'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQMF6jNMZRiP2N6t04H0cZrKBrBLkcgs_jnbQ&s'
	)
	;

INSERT INTO public.categories(
	name, description)
	VALUES 
	('Tecnología', 'Programas relacionados con la informática y la tecnología.'),
	('Negocios', 'Formación en administración y gestión empresarial.'),
	('Salud', 'Cursos relacionados con la salud y el bienestar.'),
	('Ingeniería', 'Programas enfocados en diversas ramas de la ingeniería.'),
	('Artes', 'Cursos sobre arte, música y diseño.'),
	('Ciencias Sociales', 'Programas de sociología, psicología y humanidades.'),
	('Derecho', 'Cursos y programas enfocados en leyes y regulación.'),
	('Educación', 'Formación para docentes y pedagogía.'),
	('Medio Ambiente', 'Cursos relacionados con sostenibilidad y ecología.'),
	('Deportes', 'Formación y entrenamiento en diversas disciplinas deportivas.');

INSERT INTO public.opportunities(
	name, observation, type, description, requires, guide, adicional_dates, service_channels,
	manager, modality, category_id, institution_id)
	VALUES (
	'Beca de Desarrollo Web', 'Dirigido a estudiantes de ingeniería', 'Beca',
	'Curso intensivo de desarrollo web', 'Conocimientos básicos de HTML y CSS', 
	'Guía para aplicar', 'Incluye material de estudio', 'Online y presencial',
	'Juan Perez', 'Presencial', 1, 1
	),
	('Programa de Ciberseguridad', 'Orientado a profesionales', 'Curso',
	'Formación en protección de sistemas', 'Experiencia en redes',
	'Manual de inscripción', 'Certificación incluida', 'Online',
	'Ana Lopez', 'Online', 2, 2
	),
	('Bootcamp de Big Data', 'Para analistas de datos', 'Bootcamp',
	'Curso intensivo sobre Big Data', 'Conocimientos en SQL',
	'Guía de inicio', 'Acceso a herramientas', 'Presencial', 
	'Pedro Martinez', 'Presencial', 1, 8
	),
	('Máster en Machine Learning', 'Para ingenieros de software', 'Máster',
	'Programa avanzado de ML', 'Experiencia en Python', 
	'Guía de requisitos', 'Acceso a laboratorios virtuales', 'Online', 
	'Sofia Gomez', 'Online', 4, 7
	),
	('Curso de Blockchain', 'Para interesados en criptomonedas', 'Curso',
	'Introducción a la tecnología blockchain', 'Sin requisitos previos', 
	'Guía de inscripción', 'Acceso a simuladores', 'Presencial', 
	'Carlos Sanchez', 'Presencial', 4, 6
	),
	('Especializacion en Microbiologia', 'Para interesados en agregar experiencia', 'Curso',
	'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quidem neque nihil quod aliquam sed ducimus facilis porro quibusdam nesciunt totam illo molestias magni 	placeat quisquam consectetur tenetur, qui eaque quae?', 'Sin 	requisitos previos', 
	'Guía de inscripción', 'Acceso a simuladores', 'Presencial', 
	'Carlos Sanchez', 'Presencial', 3, 5
	)
	;

INSERT INTO public.topics(
	name)
	VALUES 
	('Desarrollo Web'),
	('Programación'),
	('Big Data'),
	('Ciberseguridad'),
	('Machine Learning'),
	('DevOps'),
	('Realidad Aumentada'),
	('Blockchain'),
	('Inteligencia Artificial'),
	('Robótica');

INSERT INTO public.bootcamps(
	name, description, information, costs, institution_id)
	VALUES 
	('Fullstack Development Bootcamp',
	'Bootcamp intensivo de desarrollo web',
	'Aprende a construir aplicaciones web desde cero',
	'500.00', 1),
	('Data Science Bootcamp',
	'Formación en análisis de datos y Big Data',
	'Programa avanzado de análisis de datos',
	'800.00', 2),
	('Cybersecurity Bootcamp',
	'Protección de redes y sistemas',
	'Curso especializado en ciberseguridad',
	'600.00', 3),
	('Machine Learning Bootcamp',
	'Aprendizaje automático con Python',
	'Curso intensivo de machine learning',
	'700.00', 4),
	('Blockchain Technology Bootcamp',
	'Introducción a la blockchain y criptomonedas',
	'Curso avanzado de blockchain',
	'900.00', 5);

INSERT INTO public.bootcamp_topics(
	bootcamp_id, topic_id)
	VALUES 
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 4),
	(5, 5),
	(1, 6),
	(2, 7),
	(3, 8),
	(4, 9),
	(5, 10);

INSERT INTO public.users(
	name, email, password, rol)
	VALUES 
	('Carlos Perez', 'carlos.perez@mail.com', 'password123', 'user'),
	('Maria Rodriguez', 'maria.rodriguez@mail.com', 'password456', 'admin');

INSERT INTO public.user_opportunities(
	user_id, opportunity_id)
	VALUES 
	(1, 1),
	(2, 2),
	(1, 3),
	(1, 6),
	(2, 5),
	(2, 1),
	(1, 2),
	(2, 3),
	(2, 4),
	(1, 5);
