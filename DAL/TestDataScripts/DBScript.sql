INSERT INTO [ABDB].[dbo].[Collection] ([Title],[Description])
VALUES('Cool images i made :)','My test Collection of random images');

INSERT INTO [ABDB].[dbo].[User] ([UserName],[Email],[JoinedDate],[Bio])
VALUES ('TestUser','test@test.pl','2025-02-23',N'Hi, i''m just a test user'),
	('CoolUser','test2@test.pl','2025-02-23',N'Hi, i''m just a test user, but cool'),
	('EvenCoolerUser','test3@test.pl','2025-02-23',N'Hi, i''m just a test user, but even cooler than the rest');

INSERT INTO [ABDB].[dbo].[Follower] ([FollowerId],[FollowingId])
VALUES (1,2),(1,3),(2,3),(3,1),(3,2);

INSERT INTO [ABDB].[dbo].[Operation] ([ID],[Name],[Description])
VALUES (1,'Tip', 'Tip on an image'),
	(2,'Reaction', 'Reward for interactiong with an image'),
	(3,'Daily quota', 'Daily generation quota'),
	(4,'Posting reward', 'Reward for posting images');

INSERT INTO [ABDB].[dbo].[Model] ([ID],[Type],[ModelName],[Description])
VALUES (1,'Checkpoint','Illustrious-XL',N'Illustrious XL is an advanced Stable Diffusion XL (SD XL)-based model, developed by OnomaAI Research, optimized specifically for illustration and animation tasks. It is built upon the Kohaku XL-Beta - Revision 5 checkpoint, leveraging its robust foundation to deliver high-quality generative capabilities.
The full technical specifications for Illustrious XL are available in https://arxiv.org/abs/2409.19946. For detailed information and updates, please refer to our official release page.
As an open-source project, Illustrious XL is designed to drive innovation and support the open-source community. We encourage collaboration, knowledge sharing, and transparency around its use, aiming to foster creative advancements in technology and content creation.
While the model is open for all to use, we urge users to uphold the spirit of openness. Using the model for closed-source or proprietary monetization purposes contradicts the ethos of this project.
Illustrious XL has been developed with resources provided by OnomaAI, and we hope that the community respects this by promoting open collaboration'),
(2,'LORA','Okazu - Artist Style','The model used more than 300 high-quality original pictures for training.
This model still has a good effect of restoring the artist''s style.
In addition, because it is a LORA model that imitates the artist''s style of painting, it does not specifically tag some specific characters.'),
(3,'LyCORIS','BBC-Chan - Style LyCORIS','BBC-Chan [Illustrious] Style LyCORIS. I recommend using 1.0 Strength and using this with NoobAI-XL for best results.');

INSERT INTO [ABDB].[dbo].[Metadata] ([ModelId],[Lora1Id],[Lora2Id],[Lora1Weight],[Lora2Weight],[Sampler],[Scheduler],[Guidance],[Steps],[Height],[Width],[Seed],[PromptPoz],[PromptNeg],[GenDate])
VALUES (1,3,null,1,0,'Euler','Normal',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23'),
  (1,3,null,1,0,'Euler','Normal',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23'),
  (1,3,null,1,0,'Euler_A','Karras',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23'),
  (1,null,null,0,0,'Euler','Normal',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23'),
  (1,2,null,1,0.9,'Euler','Normal',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23'),
  (1,3,null,1,0,'Euler','Normal',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23'),
  (1,3,null,1,0,'Euler','Normal',7,30,1216,832,1234,'poz_prompt','neg_prompt','2025-02-23');

INSERT INTO [ABDB].[dbo].[Images] ([Ref],[Description],[MetadataId],[UserId],[UploadDate])
VALUES ('8dd63648-7fde-4909-8cf0-8fe6d0fce859','Kiryu Kazuma',1,1,'2025-02-23'),
  ('ba6190b9-de9e-4158-a8e8-df8e636ce8f6','Primal Miku',2,1,null),
  ('3fbe725c-3adf-47de-93b2-60f8741a2370','test image',3,1,'2025-02-23'),
  ('f4555b63-ec08-4a97-9658-3fd22fa6056e','Neko Armstrong',4,1,'2025-02-23'),
  ('84032a22-1c1d-4957-8014-8c979d043daa','Master Chief',5,3,'2025-02-23'),
  ('ea1fecaa-5805-4e63-aa55-a978dc7ab30a','Cooking Mama',6,2,'2025-02-10'),
  ('1e71ae93-d3a7-493a-b548-0f44989083cd','Random Girl',7,1,'2023-02-12');
  
 INSERT INTO [ABDB].[dbo].[Comment] ([ImageId],[CommentText])
 VALUES (1,'Very nice :)'),(2,'I don''t like that one'),(7,'Test comment');

INSERT INTO [ABDB].[dbo].[OperationsHistory] ([UserId],[OperationId],[Amount])
VALUES (1,3,100),(2,3,100),(3,3,100),(1,1,10),(3,2,1),(1,4,10);

INSERT INTO [ABDB].[dbo].[Tip] ([ImageId],[OperationId]) VALUES(1,4);

INSERT INTO [ABDB].[dbo].[Reaction] ([Type],[ImageId],[CommentId],[UserId])
VALUES (1,1,null,3);

INSERT INTO [ABDB].[dbo].[ImagesCollection] ([CollectionId],[ImageId])
VALUES (1,1),(1,2),(1,6),(1,7);