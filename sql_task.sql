select p.Name, c.Name
from Products as p
left join ProductCategories as pc on p.ID = pc.ProductID
left join Categories as c on c.ID = pc.CategoryID