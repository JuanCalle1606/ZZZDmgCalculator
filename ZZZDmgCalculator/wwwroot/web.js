// we have JQUERY

function download(url) {
	const a = document.createElement('img')
	a.src = url
	return a;
}

getDivIcon = (obj) => {
	const src = $(obj).attr("src");
	const url = src.replace("/48?", "/100?");
	return download(url);
}

getIcons = (selector) => {
	const container = $(selector);

	container.find("img").each((index, element) => {
		container.append(getDivIcon(element));
	});
}


getAgentStats = (id) => {
	const promotionTable = $("table.promotion-stats")[0];

	// get all tr elements in the table except the first one
	const rows = $(promotionTable).find("tr").slice(1);

	let logOut = "";

	const hp = [];
	const atk = [];
	const def = [];

	// for each row, if it have 4 td elements, then add the values to the arrays, if have more than
	// 4 elements skip the first one

	rows.each((index, element) => {
		const tds = $(element).find("td");

		if (tds.length == 4) {
			hp.push(parseInt($(tds[1]).text().replace(",", "")));
			atk.push(parseInt($(tds[2]).text()));
			def.push(parseInt($(tds[3]).text()));
		} else {
			hp.push(parseInt($(tds[2]).text().replace(",", "")));
			atk.push(parseInt($(tds[3]).text()));
			def.push(parseInt($(tds[4]).text()));
		}
	});

	logOut += "[\"" + id + ".Atk\"] = [" + atk + "]," + "\n";
	logOut += "[\"" + id + ".Hp\"] = [" + hp + "]," + "\n";
	logOut += "[\"" + id + ".Def\"] = [" + def + "]," + "\n";

	console.log(logOut)
}

const skillsTemplate = `new() // {name}
{
Id = "{Id}",
\tCategory = {type},
\tSkills =
\t[
\t\t{skillList}
\t]
},`;

const skillTemplate = `new() // {move}
{
\tType = {subtype},
\tDmgType = ChangeMe,
\tScales = {scales}
}
`;

getTypeShort = (type) => {
	return type.replace(" Attack", "");
}

getSubTypeShort = (type, subtype) => {
	if (type === "Basic Attack") {
		return "Basic";
	}
	if (type === "Chain Attack" && subtype === "") {
		return "Chain";
	}
	if (type === "Special Attack") {
		if (subtype === "")
			return "Special";
		return "Ex"
	}

	return subtype.replace(" Attack", "").replace(" Counter", "").replace(" Assist", "").replace(" Follow-Up", "");
}

function getSkillId(skill) {
	// Separa el string en dos partes, antes y después de los dos puntos
	const parts = skill.split(":");

	// Toma la parte después de los dos puntos, elimina espacios al inicio/final y dentro del string
	if (parts.length > 1) {
		
		// replace any character that is not a letter with ""
		return parts[1].trim().replace(/[^a-zA-Z]/g, "");
	}

	// Si el formato no es correcto, devuelve un string vacío o un mensaje de error
	return "";
}

getSkillStats = (id) => {
	let logOut = "[\n";
	const skillTable = $("table.skill-table");
	for (const skillTableElement of skillTable) {
		const trs = skillTableElement.children[0].children;

		// iterate each row
		for (let i = 1; i < trs.length; i += 2) {
			const name = trs[i].children[0].innerText;
			const type = trs[i].children[1].innerText;
			const subtype = trs[i].children[2].innerText;

			if ((type === "Dodge" && subtype === "") || subtype === "Defensive Assist" || subtype === "Additional Ability" || type === "Core Skill" || subtype === "Evasive Assist") {
				continue;
			}
			
			// for this tr get the nested table item
			let skills = $(trs[i + 1]).find("table > tbody");
			if(skills.length === 0) continue;
				
			let skillsOut = skillsTemplate.replace("{name}", name).replace("{type}", getTypeShort(type)).replace("{Id}", getSkillId(name));
			let skillList = [];

			skills = skills[0].children;
			for (let j = 1; j < skills.length; j++) {
				if (skills[j].children.length < 16) continue;
				let txt = skills[j].children[0].innerHTML;
				// if tolower(txt) containts "daze" continue
				if (txt.toLowerCase().includes("daze")) continue;

				let skillsOut = skillTemplate.replace("{move}", txt).replace("{subtype}", getSubTypeShort(type, subtype));

				let scales = "[";
				// concatenate the values of the table
				for (let k = 1; k < skills[j].children.length; k++) {
					scales += skills[j].children[k].innerText;
					if (k < skills[j].children.length - 1) {
						scales += ", ";
					}
				}
				scales += "]\n";

				skillsOut = skillsOut.replace("{scales}", scales);
				skillList.push(skillsOut);
			}

			skillsOut = skillsOut.replace("{skillList}", skillList.join(","));
			logOut += skillsOut;
		}
	}
	logOut += "]";
	console.log(logOut);
}